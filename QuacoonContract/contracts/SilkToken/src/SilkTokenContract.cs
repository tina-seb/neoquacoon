using System;
using System.ComponentModel;
using System.Numerics;

using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

namespace SilkToken
{
    [DisplayName("quacoon.SilkTokenContract")]
    [ManifestExtra("Author", "Quacoon")]
    [ManifestExtra("Email", "tina.seb@quacoon.com")]
    [ManifestExtra("Description", "Controls issuance of the Silk token")]
    [SupportedStandards("NEP-17")]
    [ContractPermission("*", "*")]
    public class SilkTokenContract : SmartContract
    {
        //Initialization Begin
        const string MAP_NAME = "SilkTokenContract";

        static readonly ulong InitialSupply = 1_000_000_000_000;

        public static BigInteger TotalSupply() => InitialSupply;
        
        public static string Symbol() => "SLK";

        public static ulong Decimals() => 8;
        
        [InitialValue("NiCeTytUjzAL8U1YWEBkyu1snNrSbrHDsW", Neo.SmartContract.ContractParameterType.Hash160)] 
        private static readonly UInt160 CentralWallet;
        private static readonly byte[] AllowancePrefix = new byte[] { 0x01, 0x02 };

        //Initialization End

        //Supply Chain Control Functions Begin

        //Pay tokens assigned as reward to task when completed 
         public static bool Pay(UInt160 to, BigInteger amount)
        {
            if(CheckAddrValid(to))
                return Transfer(CentralWallet, to, amount, null);
            else
                return false;
        }

        //If task validation fails, apply penalty to task assignee 
        public static bool Penalty(UInt160 to, BigInteger amount)
        {
            if(CheckAddrValid(to))
                return Transfer(to, CentralWallet, amount, null);
            else
                return false;
        }

        public static BigInteger BalanceOf(UInt160 account)
        {
            return Get(account);
        }

        //Supply Chain Control Functions End

        //Internal Functions Begin

        [DisplayName("Transfer")]
        public static event Action<UInt160, UInt160, BigInteger> OnTransfer;

        [DisplayName("Approval")]
        public static event Action<UInt160, UInt160, BigInteger> OnApprove;


        [InitialValue("00000040eaed7446d09c2c9f0c", Neo.SmartContract.ContractParameterType.ByteArray)] 
        private static readonly BigInteger ConvertDecimal;

        private static bool IsOwner() => Runtime.CheckWitness(GetOwner());

        private static StorageMap Balances => new StorageMap(Storage.CurrentContext, MAP_NAME);

        private static BigInteger Get(UInt160 key) => (BigInteger) Balances.Get(key);

        private static void Put(UInt160 key, BigInteger value) => Balances.Put(key, value);

        private static void Increase(UInt160 key, BigInteger value)
        {
            Put(key, Get(key) + value);
        }
        private static void Reduce(UInt160 key, BigInteger value)
        {
            var oldValue = Get(key);
            if (oldValue == value)
            {
                Balances.Delete(key);
            }
            else
            {
                Put(key, oldValue - value);
            }
        }

        public static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
        {
            if (!from.IsValid || !to.IsValid)
            {
                throw new Exception("The parameters from and to should be 20-byte addresses");
            }

            if (amount < 0) 
            {
                throw new Exception("The amount parameter must be greater than or equal to zero");
            }

            if (!from.Equals(Runtime.CallingScriptHash) && !Runtime.CheckWitness(from))
            {
                throw new Exception("No authorization.");
            }
            
            if (Get(from) < amount)
            {
                throw new Exception("Insufficient balance");
            }

            Reduce(from, amount);
            Increase(to, amount);
            OnTransfer(from, to, amount);

            if (ContractManagement.GetContract(to) != null)
            {
                Contract.Call(to, "onPayment", CallFlags.None, new object[] { from, amount, data });
            }
            
            return true;
        }
        private static bool TransferInternal(UInt160 spender, UInt160 from, UInt160 to, BigInteger amount, object data = null)
        {
            Assert(amount >= 0, "transferInternal: invalid amount-".ToByteArray().Concat(amount.ToByteArray()).ToByteString());

            bool result = true;
            if (spender != from)
            {
                result = AllowanceStorage.Reduce(from, spender, amount);
                Assert(result, "transferInternal:invalid allowance-".ToByteArray().Concat(amount.ToByteArray()).ToByteString());
            }
            if (from != UInt160.Zero && amount != 0)
            {
                result = BalanceStorage.Reduce(from, amount);
                Assert(result, "transferInternal:invalid balance-".ToByteArray().Concat(amount.ToByteArray()).ToByteString());
            }
            else if (from == UInt160.Zero)
            { 
                TotalSupplyStorage.Increase(amount);
            }
            if (to != UInt160.Zero && amount != 0)
            {
                BalanceStorage.Increase(to, amount);
            }
            else if (to == UInt160.Zero)
            {
                TotalSupplyStorage.Reduce(amount);
            }

            // Validate payable
            if (ContractManagement.GetContract(to) != null)
                Contract.Call(to, "onNEP17Payment", CallFlags.All, new object[] { from, amount, data });

            if (result)
            {
                OnTransfer(from, to, amount);
            }
            return result;
        }

        public static BigInteger Allowance(UInt160 usr, UInt160 spender) 
        {
            StorageMap allowanceMap = new(Storage.CurrentReadOnlyContext, AllowancePrefix);
            return (BigInteger)allowanceMap.Get(usr + spender);
        } 

        public static bool Approve(UInt160 usr, UInt160 spender, BigInteger amount)
        {
            Assert(CheckAddrValid(usr, spender), "approve: invalid usr or spender, usr-".ToByteArray().Concat(usr).Concat("and spender-".ToByteArray()).Concat(spender).ToByteString());
            Assert(amount > 0, "approve: invalid amount-".ToByteArray().Concat(amount.ToByteArray()).ToByteString());
            Assert(Runtime.CheckWitness(usr) || usr.Equals(Runtime.CallingScriptHash), "approve: CheckWitness failed, usr-".ToByteArray().Concat(usr).ToByteString());
            if (spender.Equals(usr)) return true;
            AllowanceStorage.Put(usr, spender, amount);
            OnApprove(usr, spender, amount);
            return true;
        }

        public static UInt160 GetOwner()
        {
            return OwnerStorage.Get();
        }

        public static bool IsAuthor(UInt160 usr)
        {
            return AuthorStorage.Get(usr) || usr.Equals(GetOwner());
        }

        public static bool SetOwner(UInt160 owner)
        {
            Assert(Runtime.CheckWitness(GetOwner()), "SetOwner: CheckWitness failed, owner-".ToByteArray().Concat(owner).ToByteString());
            Assert(CheckAddrValid(owner), "SetOwner: invalid owner-".ToByteArray().Concat(owner).ToByteString());
            OwnerStorage.Put(owner);
            return true;
        }

        public static bool Mint(UInt160 minter, UInt160 receiver, BigInteger amount)
        {
            Assert(CheckAddrValid(minter, receiver), "approve: invalid minter or receiver, usr-".ToByteArray().Concat(minter).Concat("and receiver-".ToByteArray()).Concat(receiver).ToByteString());
            Assert(amount >= 0, "mint:invalid amount-".ToByteArray().Concat(amount.ToByteArray()).ToByteString());
            Assert(IsAuthor(minter), "mint: author-".ToByteArray().Concat(minter).Concat(" is not a real author".ToByteArray()).ToByteString());
            Assert(Runtime.CheckWitness(minter) || minter.Equals(Runtime.CallingScriptHash), "mint: CheckWitness failed, author-".ToByteArray().Concat(minter).ToByteString());

            amount = amount / ConvertDecimal;
            TransferInternal(UInt160.Zero, UInt160.Zero, receiver, amount);
            return true;
        }

        public static void Update(ByteString nefFile, string manifest, object data)
        {
            Assert(IsOwner(), "upgrade: Only allowed to be called by owner.");
            ContractManagement.Update(nefFile, manifest, data);
        }

        [DisplayName("_deploy")]
        public static void Deploy(object data, bool update)
        {
            if (!update)
            {
                var tx = (Transaction) Runtime.ScriptContainer;
                var owner = (Neo.UInt160) tx.Sender;
                Increase(owner, InitialSupply);
                OnTransfer(null, owner, InitialSupply);
            }
        }

        
        private static void Assert(bool condition, string msg)
        {
            if (!condition)
            {
                throw new InvalidOperationException(msg);
            }
        }

        private static bool CheckAddrValid(params UInt160[] addrs)
        {
            bool valid = true;

            foreach (UInt160 addr in addrs)
            {
                valid = valid && addr is not null && addr.IsValid;
                if (!valid)
                    break;
            }

            return valid;
        }
    }

        //Internal Functions Begin
        //Storage Functions Begin
        public static class AllowanceStorage
        {
            private static readonly byte[] AllowancePrefix = new byte[] { 0x01, 0x02 };

            internal static void Put(UInt160 usr, UInt160 spender, BigInteger amount)
            {
                StorageMap allowanceMap = new(Storage.CurrentContext, AllowancePrefix);
                allowanceMap.Put(usr + spender, amount);
            }

            internal static BigInteger Get(UInt160 usr, UInt160 spender)
            {
                StorageMap allowanceMap = new(Storage.CurrentReadOnlyContext, AllowancePrefix);
                return (BigInteger)allowanceMap.Get(usr + spender);
            }

            internal static void Delete(UInt160 usr, UInt160 spender)
            {
                StorageMap allowanceMap = new(Storage.CurrentContext, AllowancePrefix);
                allowanceMap.Delete(usr + spender);
            }

            internal static bool Reduce(UInt160 usr, UInt160 spender, BigInteger delta)
            {
                BigInteger allowance = Get(usr, spender);
                if (allowance < delta)
                {
                    return false;
                }
                else if (allowance == delta)
                {
                    Delete(usr, spender);
                }
                else
                {
                    Put(usr, spender, allowance - delta);
                }
                return true;
            }

        }

        public static class OwnerStorage
        {
            private static readonly byte[] ownerPrefix = new byte[] { 0x03, 0x02 };

            [InitialValue("NaBUWGCLWFZTGK4V9f4pecuXmEijtGXMNX", Neo.SmartContract.ContractParameterType.Hash160)]
            private static readonly UInt160 InitialOwner;

            internal static void Put(UInt160 usr)
            {
                StorageMap map = new(Storage.CurrentContext, ownerPrefix);
                map.Put("owner", usr);
            }

            internal static UInt160 Get()
            {
                StorageMap map = new(Storage.CurrentReadOnlyContext, ownerPrefix);
                byte[] v = (byte[])map.Get("owner");
                if (v is null)
                {
                    return InitialOwner;
                }
                else if (v.Length != 20)
                {
                    return InitialOwner;
                }
                else
                {
                    return (UInt160)v;
                }
            }

            internal static void Delete()
            {
                StorageMap map = new(Storage.CurrentContext, ownerPrefix);
                map.Delete("owner");
            }
        }


        public static class BalanceStorage
        {
            private static readonly byte[] BalancePrefix = new byte[] { 0x01, 0x01 };

            internal static void Put(UInt160 usr, BigInteger amount)
            {
                StorageMap balanceMap = new(Storage.CurrentContext, BalancePrefix);
                balanceMap.Put(usr, amount);
            }

            internal static BigInteger Get(UInt160 usr)
            {
                StorageMap balanceMap = new(Storage.CurrentReadOnlyContext, BalancePrefix);
                return (BigInteger)balanceMap.Get(usr);
            }

            internal static void Delete(UInt160 usr)
            {
                StorageMap balanceMap = new(Storage.CurrentContext, BalancePrefix);
                balanceMap.Delete(usr);
            }

            internal static void Increase(UInt160 usr, BigInteger amount) => Put(usr, Get(usr) + amount);

            internal static bool Reduce(UInt160 usr, BigInteger amount)
            {
                BigInteger balance = Get(usr);
                if (balance < amount)
                {
                    return false;
                }
                else if (balance == amount)
                {
                    Delete(usr);
                }
                else
                {
                    Put(usr, balance - amount);
                }
                return true;
            }
        }

        public static class TotalSupplyStorage
        {
            private static readonly byte[] TotalSupplyPrefix = new byte[] { 0x01, 0x00 };

            private static readonly byte[] TotalSupplyKey = "totalSupply".ToByteArray();

            internal static void Put(BigInteger amount)
            {
                StorageMap balanceMap = new(Storage.CurrentContext, TotalSupplyPrefix);
                balanceMap.Put(TotalSupplyKey, amount);
            }

            internal static BigInteger Get()
            {
                StorageMap balanceMap = new(Storage.CurrentReadOnlyContext, TotalSupplyPrefix);
                return (BigInteger)balanceMap.Get(TotalSupplyKey);
            }

            internal static void Increase(BigInteger amount) => Put(Get() + amount);

            internal static void Reduce(BigInteger amount) => Put(Get() - amount);
        }

        public static class AuthorStorage
        {
            private static readonly byte[] AuthorPrefix = new byte[] { 0x01, 0x03 };

            internal static void Put(UInt160 usr)
            {
                StorageMap authorMap = new(Storage.CurrentContext, AuthorPrefix);
                authorMap.Put(usr, 1);
            }

            internal static void Delete(UInt160 usr)
            {
                StorageMap authorMap = new(Storage.CurrentContext, AuthorPrefix);
                authorMap.Delete(usr);
            }

            internal static bool Get(UInt160 usr)
            {
                StorageMap authorMap = new(Storage.CurrentReadOnlyContext, AuthorPrefix);
                return (BigInteger)authorMap.Get(usr) == 1;
            }

            internal static BigInteger Count()
            {
                StorageMap authorMap = new(Storage.CurrentReadOnlyContext, AuthorPrefix);
                var iterator = authorMap.Find();
                BigInteger count = 0;
                while (iterator.Next())
                {
                    count ++;
                }
                return count;
            }

            internal static UInt160[] Find(BigInteger count)
            {
                StorageMap authorMap = new(Storage.CurrentReadOnlyContext, AuthorPrefix);
                var iterator = authorMap.Find(FindOptions.RemovePrefix | FindOptions.KeysOnly);
                UInt160[] addrs = new UInt160[(uint)count];
                uint i = 0;
                while (iterator.Next())
                {
                    addrs[i] = (UInt160)iterator.Value;
                    i++;
                }
                return addrs;
            }

            internal static Iterator Find()
            {
                StorageMap authorMap = new(Storage.CurrentReadOnlyContext, AuthorPrefix);
                return authorMap.Find();
            }
        }

    // Storage Functions End
    
}