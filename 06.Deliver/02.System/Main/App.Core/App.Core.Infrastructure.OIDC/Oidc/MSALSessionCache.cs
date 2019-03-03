﻿using System.Threading;
using System.Web;
using Microsoft.Identity.Client;

namespace App.Core.Infrastructure.IDA.Oidc
{
    /// <summary>
    ///     File needed by Web MVC (not needed when being a WebAPI site only).
    /// </summary>
    public class MSALSessionCache
    {
        private static readonly ReaderWriterLockSlim SessionLock =
            new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly TokenCache cache = new TokenCache();
        private readonly string CacheId = string.Empty;
        private readonly HttpContextBase httpContext;
        private readonly string UserId = string.Empty;

        public MSALSessionCache(string userId, HttpContextBase httpcontext)
        {
            // not object, we want the SUB
            this.UserId = userId;
            this.CacheId = this.UserId + "_TokenCache";
            this.httpContext = httpcontext;
            Load();
        }

        public TokenCache GetMsalCacheInstance()
        {
            this.cache.SetBeforeAccess(BeforeAccessNotification);
            this.cache.SetAfterAccess(AfterAccessNotification);
            Load();
            return this.cache;
        }

        public void SaveUserStateValue(string state)
        {
            SessionLock.EnterWriteLock();
            this.httpContext.Session[this.CacheId + "_state"] = state;
            SessionLock.ExitWriteLock();
        }

        public string ReadUserStateValue()
        {
            var state = string.Empty;
            SessionLock.EnterReadLock();
            state = (string) this.httpContext.Session[this.CacheId + "_state"];
            SessionLock.ExitReadLock();
            return state;
        }

        public void Load()
        {
            SessionLock.EnterReadLock();
            this.cache.Deserialize((byte[]) this.httpContext.Session[this.CacheId]);
            SessionLock.ExitReadLock();
        }

        public void Persist()
        {
            SessionLock.EnterWriteLock();

            // Optimistically set HasStateChanged to false. We need to do it early to avoid losing changes made by a concurrent thread.
            this.cache.HasStateChanged = false;

            // Reflect changes in the persistent store
            this.httpContext.Session[this.CacheId] = this.cache.Serialize();
            SessionLock.ExitWriteLock();
        }

        // Triggered right before MSAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        private void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            Load();
        }

        // Triggered right after MSAL accessed the cache.
        private void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (this.cache.HasStateChanged)
            {
                Persist();
            }
        }
    }
}