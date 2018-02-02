﻿

namespace App.Core.Infrastructure.Services
{
    using System.IO;

    public interface IAzureStorageService
    {
        void Persist(byte[] bytes, string targetRelativePath);
        void Persist(Stream contents, string targetRelativePath);
    }
}