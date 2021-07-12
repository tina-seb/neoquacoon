$('#profilefile2').change(function () {
    Swal.fire({
        icon: 'success',
        title: "Thank you!",
        html: "The allotted tokens for this task will be processed shortly to your wallet.",
        showConfirmButton: false,
        width: 300,
        padding: '3em',
    })

    PublishInvoke(); //Store user-wallet mapping in DB and pass in parameters
});


async function PublishInvoke() {
    const rpcAddress = "http://localhost:50012";
    const scriptHash = "0x44f2d1db7d843e1675a720b3128f2f054f88d3f5";
    const networkMagic = 2476887194;
    const account = new Neon.wallet.Account("e1257046ed9cdf275560c69048111436891b709aff168fb4953403f2f80fbbca");

    const pcontract = new Neon.experimental.SmartContract(
        Neon.u.HexString.fromHex(scriptHash), { networkMagic, rpcAddress, account }
    );

    const pparams = [
        Neon.sc.ContractParam.hash160("NiCeTytUjzAL8U1YWEBkyu1snNrSbrHDsW"),
        Neon.sc.ContractParam.hash160("NUozzVWCkL1JyjtduzUdmf8o3XSVi4MNDN"),
        10,
        []
    ]

    const signers = [{ account: scriptHash, scopes: "Global" }];

    var res = await pcontract.invoke("transfer", pparams, signers);
}

async function ReadInvoke() {

    const rpcAddress = "http://localhost:50012";
    const scriptHash = "0x44f2d1db7d843e1675a720b3128f2f054f88d3f5";
    const networkMagic = 2476887194;
    const account = new Neon.wallet.Account("e1257046ed9cdf275560c69048111436891b709aff168fb4953403f2f80fbbca");
    const walletAddress = "NXcTSTJzxJB9YYczGgtHn94NseM4fpMr96";

    //define our invocation
    const contract = new Neon.experimental.SmartContract(
        Neon.u.HexString.fromHex(scriptHash), { networkMagic, rpcAddress }
    );

    const signers = [{ account: scriptHash, scopes: "Global" }];

    const params = [Neon.sc.ContractParam.hash160(walletAddress)];

    var res = await contract.testInvoke("balanceOf", params, signers);

    const value = res.stack[0].value;

    document.getElementById("storage").innerHTML = value
}
