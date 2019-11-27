using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cam.Ledger;
using Cam.SmartContract;
using Cam.VM;
using System.Text;
using System.Numerics;
using System.Reflection;
using System;

namespace Cam.UnitTests
{
    [TestClass]
    public class UT_InteropPrices
    {
        CamService uut;

        [TestInitialize]
        public void TestSetup()
        {
            uut = new CamService(TriggerType.Application, null);
        }

        [TestMethod]
        public void CamServiceFixedPriceWithReflection()
        {
            // testing reflection with public methods too
            MethodInfo GetPrice = typeof(CamService).GetMethod("GetPrice", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(uint) }, null);
            GetPrice.Invoke(uut, new object[]{"Cam.Runtime.CheckWitness".ToInteropMethodHash()}).Should().Be(200L);
        }

        [TestMethod]
        public void CamServiceFixedPrices()
        {
            uut.GetPrice("Cam.Runtime.GetTrigger".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Runtime.CheckWitness".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.Runtime.Notify".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Runtime.Log".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Runtime.GetTime".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Runtime.Serialize".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Runtime.Deserialize".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Blockchain.GetHeight".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Blockchain.GetHeader".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Blockchain.GetBlock".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.Blockchain.GetTransaction".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Blockchain.GetTransactionHeight".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Blockchain.GetAccount".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Blockchain.GetValidators".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.Blockchain.GetAsset".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Blockchain.GetContract".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Header.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetVersion".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetPrevHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetMerkleRoot".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetTimestamp".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetIndex".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetConsensusData".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Header.GetNextConsensus".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Block.GetTransactionCount".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Block.GetTransactions".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Block.GetTransaction".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetType".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetAttributes".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetInputs".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetOutputs".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Transaction.GetReferences".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.Transaction.GetUnspentCoins".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.Transaction.GetWitnesses".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("Cam.InvocationTransaction.GetScript".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Witness.GetVerificationScript".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Attribute.GetUsage".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Attribute.GetData".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Input.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Input.GetIndex".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Output.GetAssetId".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Output.GetValue".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Output.GetScriptHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Account.GetScriptHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Account.GetVotes".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Account.GetBalance".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Account.IsStandard".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Asset.GetAssetId".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetAssetType".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetAmount".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetAvailable".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetPrecision".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetOwner".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetAdmin".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Asset.GetIssuer".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Contract.Destroy".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Contract.GetScript".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Contract.IsPayable".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Contract.GetStorageContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Storage.GetContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Storage.GetReadOnlyContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Storage.Get".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Storage.Delete".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("Cam.Storage.Find".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.StorageContext.AsReadOnly".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Enumerator.Create".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Enumerator.Next".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Enumerator.Value".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Enumerator.Concat".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Create".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Key".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Keys".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Values".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Concat".ToInteropMethodHash()).Should().Be(1);

            #region Aliases
            uut.GetPrice("Cam.Iterator.Next".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("Cam.Iterator.Value".ToInteropMethodHash()).Should().Be(1);
            #endregion

            #region Old APIs
            uut.GetPrice("AntShares.Runtime.CheckWitness".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("AntShares.Runtime.Notify".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Runtime.Log".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Blockchain.GetHeight".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Blockchain.GetHeader".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Blockchain.GetBlock".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("AntShares.Blockchain.GetTransaction".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Blockchain.GetAccount".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Blockchain.GetValidators".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("AntShares.Blockchain.GetAsset".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Blockchain.GetContract".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Header.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetVersion".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetPrevHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetMerkleRoot".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetTimestamp".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetConsensusData".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Header.GetNextConsensus".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Block.GetTransactionCount".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Block.GetTransactions".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Block.GetTransaction".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetType".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetAttributes".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetInputs".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetOutputs".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Transaction.GetReferences".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("AntShares.Attribute.GetUsage".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Attribute.GetData".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Input.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Input.GetIndex".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Output.GetAssetId".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Output.GetValue".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Output.GetScriptHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Account.GetScriptHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Account.GetVotes".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Account.GetBalance".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetAssetId".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetAssetType".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetAmount".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetAvailable".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetPrecision".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetOwner".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetAdmin".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Asset.GetIssuer".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Contract.Destroy".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Contract.GetScript".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Contract.GetStorageContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Storage.GetContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("AntShares.Storage.Get".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("AntShares.Storage.Delete".ToInteropMethodHash()).Should().Be(100);
            #endregion
        }

        [TestMethod]
        public void StandardServiceFixedPrices()
        {
            uut.GetPrice("System.Runtime.Platform".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.GetTrigger".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.CheckWitness".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("System.Runtime.Notify".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.Log".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.GetTime".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.Serialize".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Runtime.Deserialize".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Blockchain.GetHeight".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Blockchain.GetHeader".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("System.Blockchain.GetBlock".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("System.Blockchain.GetTransaction".ToInteropMethodHash()).Should().Be(200);
            uut.GetPrice("System.Blockchain.GetTransactionHeight".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("System.Blockchain.GetContract".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("System.Header.GetIndex".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Header.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Header.GetPrevHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Header.GetTimestamp".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Block.GetTransactionCount".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Block.GetTransactions".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Block.GetTransaction".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Transaction.GetHash".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Contract.Destroy".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Contract.GetStorageContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Storage.GetContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Storage.GetReadOnlyContext".ToInteropMethodHash()).Should().Be(1);
            uut.GetPrice("System.Storage.Get".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("System.Storage.Delete".ToInteropMethodHash()).Should().Be(100);
            uut.GetPrice("System.StorageContext.AsReadOnly".ToInteropMethodHash()).Should().Be(1);
        }

        [TestMethod]
        public void ApplicationEngineFixedPrices()
        {
            // ApplicationEngine.GetPriceForSysCall is protected, so we will access through reflection
            MethodInfo GetPriceForSysCall = typeof(ApplicationEngine).GetMethod("GetPriceForSysCall", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[]{}, null);

            // System.Runtime.CheckWitness: f827ec8c (price is 200)
            byte[] SyscallSystemRuntimeCheckWitnessHash = new byte[]{0x68, 0x04, 0xf8, 0x27, 0xec, 0x8c};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                ae.LoadScript(SyscallSystemRuntimeCheckWitnessHash);
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(200L);
            }

            // "System.Runtime.CheckWitness" (27 bytes -> 0x1b) - (price is 200)
            byte[] SyscallSystemRuntimeCheckWitnessString = new byte[]{0x68, 0x1b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x52, 0x75, 0x6e, 0x74, 0x69, 0x6d, 0x65, 0x2e, 0x43, 0x68, 0x65, 0x63, 0x6b, 0x57, 0x69, 0x74, 0x6e, 0x65, 0x73, 0x73};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                ae.LoadScript(SyscallSystemRuntimeCheckWitnessString);
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(200L);
            }

            // System.Storage.GetContext: 9bf667ce (price is 1)
            byte[] SyscallSystemStorageGetContextHash = new byte[]{0x68, 0x04, 0x9b, 0xf6, 0x67, 0xce};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                ae.LoadScript(SyscallSystemStorageGetContextHash);
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(1L);
            }

            // System.Storage.Get: 925de831 (price is 100)
            byte[] SyscallSystemStorageGetHash = new byte[]{0x68, 0x04, 0x92, 0x5d, 0xe8, 0x31};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                ae.LoadScript(SyscallSystemStorageGetHash);
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(100L);
            }
        }

        [TestMethod]
        public void ApplicationEngineVariablePrices()
        {
            // ApplicationEngine.GetPriceForSysCall is protected, so we will access through reflection
            MethodInfo GetPriceForSysCall = typeof(ApplicationEngine).GetMethod("GetPriceForSysCall", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, new Type[]{}, null);

            // Cam.Asset.Create: 83c5c61f
            byte[] SyscallAssetCreateHash = new byte[]{0x68, 0x04, 0x83, 0xc5, 0xc6, 0x1f};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                ae.LoadScript(SyscallAssetCreateHash);
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(5000L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Asset.Renew: 78849071 (requires push 09 push 09 before)
            byte[] SyscallAssetRenewHash = new byte[]{0x59, 0x59, 0x68, 0x04, 0x78, 0x84, 0x90, 0x71};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallAssetRenewHash);
                debugger.StepInto(); // push 9
                debugger.StepInto(); // push 9
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(9L * 5000L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Contract.Create: f66ca56e (requires push properties on fourth position)
            byte[] SyscallContractCreateHash00 = new byte[]{(byte)ContractPropertyState.NoProperty, 0x00, 0x00, 0x00, 0x68, 0x04, 0xf6, 0x6c, 0xa5, 0x6e};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallContractCreateHash00);
                debugger.StepInto(); // push 0 - ContractPropertyState.NoProperty
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(100L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Contract.Create: f66ca56e (requires push properties on fourth position)
            byte[] SyscallContractCreateHash01 = new byte[]{0x51, 0x00, 0x00, 0x00, 0x68, 0x04, 0xf6, 0x6c, 0xa5, 0x6e};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallContractCreateHash01);
                debugger.StepInto(); // push 01 - ContractPropertyState.HasStorage
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(500L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Contract.Create: f66ca56e (requires push properties on fourth position)
            byte[] SyscallContractCreateHash02 = new byte[]{0x52, 0x00, 0x00, 0x00, 0x68, 0x04, 0xf6, 0x6c, 0xa5, 0x6e};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallContractCreateHash02);
                debugger.StepInto(); // push 02 - ContractPropertyState.HasDynamicInvoke
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(600L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Contract.Create: f66ca56e (requires push properties on fourth position)
            byte[] SyscallContractCreateHash03 = new byte[]{0x53, 0x00, 0x00, 0x00, 0x68, 0x04, 0xf6, 0x6c, 0xa5, 0x6e};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallContractCreateHash03);
                debugger.StepInto(); // push 03 - HasStorage and HasDynamicInvoke
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(1000L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // Cam.Contract.Migrate: 471b6290 (requires push properties on fourth position)
            byte[] SyscallContractMigrateHash00 = new byte[]{(byte)ContractPropertyState.NoProperty, 0x00, 0x00, 0x00, 0x68, 0x04, 0x47, 0x1b, 0x62, 0x90};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallContractMigrateHash00);
                debugger.StepInto(); // push 0 - ContractPropertyState.NoProperty
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                debugger.StepInto(); // push 0
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(100L * 100000000L / 100000); // assuming private ae.ratio = 100000
            }

            // System.Storage.Put: e63f1884 (requires push key and value)
            byte[] SyscallStoragePutHash = new byte[]{0x53, 0x53, 0x00, 0x68, 0x04, 0xe6, 0x3f, 0x18, 0x84};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallStoragePutHash);
                debugger.StepInto(); // push 03 (length 1)
                debugger.StepInto(); // push 03 (length 1)
                debugger.StepInto(); // push 00
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(1000L); //((1+1-1) / 1024 + 1) * 1000);
            }

            // System.Storage.PutEx: 73e19b3a (requires push key and value)
            byte[] SyscallStoragePutExHash = new byte[]{0x53, 0x53, 0x00, 0x68, 0x04, 0x73, 0xe1, 0x9b, 0x3a};
            using ( ApplicationEngine ae = new ApplicationEngine(TriggerType.Application, null, null, Fixed8.Zero) )
            {
                Debugger debugger = new Debugger(ae);
                ae.LoadScript(SyscallStoragePutExHash);
                debugger.StepInto(); // push 03 (length 1)
                debugger.StepInto(); // push 03 (length 1)
                debugger.StepInto(); // push 00
                GetPriceForSysCall.Invoke(ae, new object[]{}).Should().Be(1000L); //((1+1-1) / 1024 + 1) * 1000);
            }
        }
    }
}
