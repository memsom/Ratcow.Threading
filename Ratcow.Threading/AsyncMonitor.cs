﻿/*
 * Copyright 2018 Rat Cow Software and Matt Emson. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list of
 *    conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list
 *    of conditions and the following disclaimer in the documentation and/or other materials
 *    provided with the distribution.
 * 3. Neither the name of the Rat Cow Software nor the names of its contributors may be used
 *    to endorse or promote products derived from this software without specific prior written
 *    permission.
 *
 * THIS SOFTWARE IS PROVIDED BY RAT COW SOFTWARE "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of Rat Cow Software and Matt Emson.
 *
 */

using System;
using System.Threading.Tasks;

namespace Ratcow.Threading
{
    /// <summary>
    /// This is vaguely based on the System.Threading.Monitor class.
    /// 
    /// I left out some of the more complex stuff because this is for Task
    /// based usage and only implements what I needed for that specific use 
    /// case.
    /// </summary>
    public class AsyncMonitor
    {
        public static async Task Enter(AsyncLockObject obj)
        {
            await obj.Lock();
        }

        public static void Exit(AsyncLockObject obj)
        {
            obj.Unlock();
        }

        public static bool IsEntered(AsyncLockObject obj)
        {
            return obj.IsLocked;
        }
       
        public static async Task<bool> TryEnter(AsyncLockObject obj, TimeSpan timeout)
        {
            return await obj.Lock(timeout);
        }

        public static async Task<bool> TryEnter(AsyncLockObject obj, int millisecondsTimeout)
        {
            return await TryEnter(obj, TimeSpan.FromMilliseconds(millisecondsTimeout));
        }
     
        public static async Task<bool> TryEnter(AsyncLockObject obj)
        {
            return await obj.Lock(TimeSpan.FromMilliseconds(5));
        }       
    }
}
