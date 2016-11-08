﻿/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Collections.Generic;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods storing, retrieving, and creating keys.
    /// </summary>
    public class KeyManager : Manager
    {
        /// <summary>
        /// Gets a key from secure repository.
        /// </summary>
        /// <param name="alias">The name of a key to retrieve.</param>
        /// <param name="password">
        /// The password used in decrypting a key value.
        /// If password of policy is provided in SaveKey(), the same password should be provided.
        /// </param>
        /// <returns>A key specified by alias.</returns>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">
        /// Key does not exist with the alias or key-protecting password isn't matched.
        /// </exception>
        static public Key Get(string alias, string password)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetKey(alias, password, out ptr),
                    "Failed to get key. alias=" + alias);
                return new Key(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.KeyFree(ptr);
            }
        }

        /// <summary>
        /// Gets all alias of keys which the client can access.
        /// </summary>
        /// <returns>All alias of keys which the client can access.</returns>
        /// <exception cref="ArgumentException">No alias to get.</exception>
        static public IEnumerable<string> GetAliases()
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcManager.GetKeyAliasList(out ptr),
                    "Failed to get key aliases.");
                return new SafeAliasListHandle(ptr).Aliases;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.AliasListAllFree(ptr);
            }
        }

        /// <summary>
        /// Stores a key inside secure repository based on the provided policy.
        /// </summary>
        /// <param name="alias">The name of a key to be stored.</param>
        /// <param name="key">The key's binary value to be stored.</param>
        /// <param name="policy">The policy about how to store a key securely.</param>
        /// <exception cref="ArgumentException">Alias argument is null or invalid format. key argument is invalid format.</exception>
        /// <exception cref="InvalidOperationException">Key with alias does already exist.</exception>
        /// <remarks>Type in key may be set to KeyType.None as an input. Type is determined inside secure reposioty during storing keys.</remarks>
        /// <remarks>If password in policy is provided, the key is additionally encrypted with the password in policy.</remarks>
        static public void Save(string alias, Key key, Policy policy)
        {
            int ret = Interop.CkmcManager.SaveKey(alias, key.ToCkmcKey(), policy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to save Key. alias=" + alias);
        }

        /// <summary>
        /// Creates RSA private/public key pair and stores them inside secure repository based on each policy.
        /// </summary>
        /// <param name="size">The size of key strength to be created. 1024, 2048, and 4096 are supported.</param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">The policy about how to store a private key securely.</param>
        /// <param name="publicKeyPolicy">The policy about how to store a public key securely.</param>
        /// <exception cref="ArgumentException">size is invalid. privateKeyAlias or publicKeyAlias is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">Key with privateKeyAlias or publicKeyAlias does already exist.</exception>
        /// <remarks>If password in policy is provided, the key is additionally encrypted with the password in policy.</remarks>
        static public void CreateRsaKeyPair(int size, string privateKeyAlias, string publicKeyAlias,
                                            Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            if (size != 1024 && size != 2048 && size != 4096)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));

            int ret = Interop.CkmcManager.CreateKeyPairRsa((UIntPtr)size, privateKeyAlias, publicKeyAlias,
                                        privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to Create RSA Key Pair");
        }

        /// <summary>
        /// Creates DSA private/public key pair and stores them inside secure repository based on each policy.
        /// </summary>
        /// <param name="size">The size of key strength to be created. 1024, 2048, 3072, and 4096 are supported.</param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">The policy about how to store a private key securely.</param>
        /// <param name="publicKeyPolicy">The policy about how to store a public key securely.</param>
        /// <exception cref="ArgumentException">size is invalid. privateKeyAlias or publicKeyAlias is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">Key with privateKeyAlias or publicKeyAlias does already exist.</exception>
        /// <remarks>If password in policy is provided, the key is additionally encrypted with the password in policy.</remarks>
        static public void CreateDsaKeyPair(int size, string privateKeyAlias, string publicKeyAlias,
                                            Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            if (size != 1024 && size != 2048 && size != 3072 && size != 4096)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));

            int ret = Interop.CkmcManager.CreateKeyPairDsa((UIntPtr)size, privateKeyAlias, publicKeyAlias,
                                        privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to Create DSA Key Pair");
        }

        /// <summary>
        /// Creates ECDSA private/public key pair and stores them inside secure repository based on each policy.
        /// </summary>
        /// <param name="type">The type of elliptic curve of ECDSA.</param>
        /// <param name="privateKeyAlias">The name of private key to be stored.</param>
        /// <param name="publicKeyAlias">The name of public key to be stored.</param>
        /// <param name="privateKeyPolicy">The policy about how to store a private key securely.</param>
        /// <param name="publicKeyPolicy">The policy about how to store a public key securely.</param>
        /// <exception cref="ArgumentException">Elliptic curve type is invalid. privateKeyAlias or publicKeyAlias is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">Key with privateKeyAlias or publicKeyAlias does already exist.</exception>
        /// <remarks>If password in policy is provided, the key is additionally encrypted with the password in policy.</remarks>
        static public void CreateEcdsaKeyPair(EllipticCurveType type, string privateKeyAlias, string publicKeyAlias,
                                    Policy privateKeyPolicy, Policy publicKeyPolicy)
        {
            int ret = Interop.CkmcManager.CreateKeyPairEcdsa((int)type, privateKeyAlias, publicKeyAlias,
                                        privateKeyPolicy.ToCkmcPolicy(), publicKeyPolicy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to Create ECDSA Key Pair");
        }

        /// <summary>
        /// Creates AES key and stores it inside secure repository based on each policy.
        /// </summary>
        /// <param name="size">The size of key strength to be created. 128, 192 and256 are supported.</param>
        /// <param name="keyAlias">The name of key to be stored.</param>
        /// <param name="policy">The policy about how to store the key securely.</param>
        /// <exception cref="ArgumentException">Key size is invalid. keyAlias is null or invalid format.</exception>
        /// <exception cref="InvalidOperationException">Key with privateKeyAlias or publicKeyAlias does already exist.</exception>
        /// <remarks>If password in policy is provided, the key is additionally encrypted with the password in policy.</remarks>
        static public void CreateAesKey(int size, string keyAlias, Policy policy)
        {
            if (size != 128 && size != 192 && size != 256)
                throw new ArgumentException(string.Format("Invalid key size({0})", size));

            int ret = Interop.CkmcManager.CreateKeyAes((UIntPtr)size, keyAlias, policy.ToCkmcPolicy());
            Interop.CheckNThrowException(ret, "Failed to AES Key");
        }
    }
}
