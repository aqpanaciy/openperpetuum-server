﻿
namespace Perpetuum.Wallets
{
    public interface IWallet<TCredit>
    {
        TCredit Balance { get; set; }
    }
}