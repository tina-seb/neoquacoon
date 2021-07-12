﻿using System.Collections.Generic;
using System.Linq;

using FluentAssertions;
using Neo.Assertions;
using Neo.BlockchainToolkit;
using Neo.BlockchainToolkit.Models;
using Neo.BlockchainToolkit.SmartContract;
using Neo.SmartContract;
using Neo.VM;
using NeoTestHarness;
using Xunit;

namespace SilkTokenTests
{
    [CheckpointPath("test/bin/checkpoints/contract-deployed.neoxp-checkpoint")]
    public class SilkTokenContractTests : IClassFixture<CheckpointFixture<SilkTokenContractTests>>
    {
        readonly CheckpointFixture fixture;
        readonly ExpressChain chain;

        public SilkTokenContractTests(CheckpointFixture<SilkTokenContractTests> fixture)
        {
            this.fixture = fixture;
            this.chain = fixture.FindChain("SilkTokenTests.neo-express");
        }

        [Fact]
        public void contract_owner_in_storage()
        {
            var settings = chain.GetProtocolSettings();
            var owner = chain.GetDefaultAccount("owner").ToScriptHash(settings.AddressVersion);

            using var snapshot = fixture.GetSnapshot();

            // check to make sure contract owner stored in contract storage
            var storages = snapshot.GetContractStorages<SilkTokenContract>();
            storages.Count().Should().Be(1);
            storages.TryGetValue("MetadataOwner", out var item).Should().BeTrue();
            item!.Should().Be(owner);
        }

        [Fact]
        public void can_change_number()
        {
            var settings = chain.GetProtocolSettings();
            var alice = chain.GetDefaultAccount("alice").ToScriptHash(settings.AddressVersion);

            using var snapshot = fixture.GetSnapshot();

            // ExecuteScript converts the provided expression(s) into a Neo script
            // loads them into the engine and executes it 
            using var engine = new TestApplicationEngine(snapshot, settings, alice);

            //engine.ExecuteScript<SilkTokenContract>(c => c.changeNumber(42));

            engine.State.Should().Be(VMState.HALT);
            engine.ResultStack.Should().HaveCount(1);
            engine.ResultStack.Peek(0).Should().BeTrue();

            // ensure that notification is triggered
            engine.Notifications.Should().HaveCount(1);
            engine.Notifications[0].EventName.Should().Be("NumberChanged");
            engine.Notifications[0].State[0].Should().BeEquivalentTo(alice);
            engine.Notifications[0].State[1].Should().BeEquivalentTo(42);

            // ensure correct storage item was created 
            var storages = snapshot.GetContractStorages<SilkTokenContract>();
            var contractStorage = storages.StorageMap("SilkTokenContract");
            contractStorage.TryGetValue(alice, out var item).Should().BeTrue();
            item!.Should().Be(42);
        }
    }
}
