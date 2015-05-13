// Missing from ASP.NET 5 both DNX451 and DNXCore5
namespace System.Transactions
{

    // Summary:
    //     Contains methods used for transaction management. This class cannot be inherited.
    //     WB: Only including the method referenced here in TransactionSettings.cs
    public static class TransactionManager
    {
        // Summary:
        //     Gets the default timeout interval for new transactions.
        //
        // Returns:
        //     A System.TimeSpan value that specifies the timeout interval for new transactions.
        public static TimeSpan DefaultTimeout
        {
            get
            {
                return new TimeSpan(0, 1, 0); // WB: determined empirically
            }
        }
        //
        // Summary:
        //     Gets or sets a custom transaction factory.
        //
        // Returns:
        //     A System.Transactions.HostCurrentTransactionCallback that contains a custom
        //     transaction factory.
        //public static HostCurrentTransactionCallback HostCurrentCallback { get; set; }
        //
        // Summary:
        //     Gets the default maximum timeout interval for new transactions.
        //
        // Returns:
        //     A System.TimeSpan value that specifies the maximum timeout interval that
        //     is allowed when creating new transactions.
        //public static TimeSpan MaximumTimeout { get; }

        // Summary:
        //     Indicates that a distributed transaction has started.
        //public static event TransactionStartedEventHandler DistributedTransactionStarted;

        // Summary:
        //     Notifies the transaction manager that a resource manager recovering from
        //     failure has finished reenlisting in all unresolved transactions.
        //
        // Parameters:
        //   resourceManagerIdentifier:
        //     A System.Guid that uniquely identifies the resource to be recovered from.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The resourceManagerIdentifier parameter is null.
        //public static void RecoveryComplete(Guid resourceManagerIdentifier);
        //
        // Summary:
        //     Reenlists a durable participant in a transaction.
        //
        // Parameters:
        //   resourceManagerIdentifier:
        //     A System.Guid that uniquely identifies the resource manager.
        //
        //   recoveryInformation:
        //     Contains additional information of recovery information.
        //
        //   enlistmentNotification:
        //     A resource object that implements System.Transactions.IEnlistmentNotification
        //     to receive notifications.
        //
        // Returns:
        //     An System.Transactions.Enlistment that describes the enlistment.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     recoveryInformation is invalid.-or-Transaction Manager information in recoveryInformation
        //     does not match the configured transaction manager.-or-RecoveryInformation
        //     is not recognized by System.Transactions.
        //
        //   System.InvalidOperationException:
        //     System.Transactions.TransactionManager.RecoveryComplete(System.Guid) has
        //     already been called for the specified resourceManagerIdentifier. The reenlistment
        //     is rejected.
        //
        //   System.Transactions.TransactionException:
        //     The resourceManagerIdentifier does not match the content of the specified
        //     recovery information in recoveryInformation.
        //public static Enlistment Reenlist(Guid resourceManagerIdentifier, byte[] recoveryInformation, IEnlistmentNotification enlistmentNotification);

    }
}
