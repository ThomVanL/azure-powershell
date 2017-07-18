// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("New", "AzureRmDiskConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDisk))]
    public class NewAzureRmDiskConfigCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [Alias("AccountType")]
        public StorageAccountTypes? SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public OperatingSystemTypes? OsType { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public int? DiskSizeGB { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public DiskCreateOption? CreateOption { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string StorageAccountId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public ImageDiskReference ImageReference { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string SourceUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public bool? EncryptionSettingsEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public KeyVaultAndSecretReference DiskEncryptionKey { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public KeyVaultAndKeyReference KeyEncryptionKey { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Disk", "New"))
            {
                Run();
            }
        }

        private void Run()
        {
            // Sku
            Microsoft.Azure.Management.Compute.Models.DiskSku vSku = null;

            // CreationData
            Microsoft.Azure.Management.Compute.Models.CreationData vCreationData = null;

            // EncryptionSettings
            Microsoft.Azure.Management.Compute.Models.EncryptionSettings vEncryptionSettings = null;

            if (this.SkuName != null)
            {
                if (vSku == null)
                {
                    vSku = new Microsoft.Azure.Management.Compute.Models.DiskSku();
                }
                vSku.Name = this.SkuName;
            }

            if (this.CreateOption.HasValue)
            {
                if (vCreationData == null)
                {
                    vCreationData = new Microsoft.Azure.Management.Compute.Models.CreationData();
                }
                vCreationData.CreateOption = this.CreateOption.Value;
            }

            if (this.StorageAccountId != null)
            {
                if (vCreationData == null)
                {
                    vCreationData = new Microsoft.Azure.Management.Compute.Models.CreationData();
                }
                vCreationData.StorageAccountId = this.StorageAccountId;
            }

            if (this.ImageReference != null)
            {
                if (vCreationData == null)
                {
                    vCreationData = new Microsoft.Azure.Management.Compute.Models.CreationData();
                }
                vCreationData.ImageReference = this.ImageReference;
            }

            if (this.SourceUri != null)
            {
                if (vCreationData == null)
                {
                    vCreationData = new Microsoft.Azure.Management.Compute.Models.CreationData();
                }
                vCreationData.SourceUri = this.SourceUri;
            }

            if (this.SourceResourceId != null)
            {
                if (vCreationData == null)
                {
                    vCreationData = new Microsoft.Azure.Management.Compute.Models.CreationData();
                }
                vCreationData.SourceResourceId = this.SourceResourceId;
            }

            if (this.EncryptionSettingsEnabled != null)
            {
                if (vEncryptionSettings == null)
                {
                    vEncryptionSettings = new Microsoft.Azure.Management.Compute.Models.EncryptionSettings();
                }
                vEncryptionSettings.Enabled = this.EncryptionSettingsEnabled;
            }

            if (this.DiskEncryptionKey != null)
            {
                if (vEncryptionSettings == null)
                {
                    vEncryptionSettings = new Microsoft.Azure.Management.Compute.Models.EncryptionSettings();
                }
                vEncryptionSettings.DiskEncryptionKey = this.DiskEncryptionKey;
            }

            if (this.KeyEncryptionKey != null)
            {
                if (vEncryptionSettings == null)
                {
                    vEncryptionSettings = new Microsoft.Azure.Management.Compute.Models.EncryptionSettings();
                }
                vEncryptionSettings.KeyEncryptionKey = this.KeyEncryptionKey;
            }


            var vDisk = new PSDisk
            {
                OsType = this.OsType,
                DiskSizeGB = this.DiskSizeGB,
                Location = this.Location,
                Tags = (this.Tag == null) ? null : this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value),
                Sku = vSku,
                CreationData = vCreationData,
                EncryptionSettings = vEncryptionSettings,
            };

            WriteObject(vDisk);
        }
    }
}

