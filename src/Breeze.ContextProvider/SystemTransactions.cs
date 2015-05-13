// Missing from ASP.NET 5 both DNX451 and DNXCore5
namespace System.Transactions
{
    // Summary:
    //     Specifies the isolation level of a transaction.
    public enum IsolationLevel
    {
        // Summary:
        //     Volatile data can be read but not modified, and no new data can be added
        //     during the transaction.
        Serializable = 0,
        //
        // Summary:
        //     Volatile data can be read but not modified during the transaction. New data
        //     can be added during the transaction.
        RepeatableRead = 1,
        //
        // Summary:
        //     Volatile data cannot be read during the transaction, but can be modified.
        ReadCommitted = 2,
        //
        // Summary:
        //     Volatile data can be read and modified during the transaction.
        ReadUncommitted = 3,
        //
        // Summary:
        //     Volatile data can be read. Before a transaction modifies data, it verifies
        //     if another transaction has changed the data after it was initially read.
        //     If the data has been updated, an error is raised. This allows a transaction
        //     to get to the previously committed value of the data.
        Snapshot = 4,
        //
        // Summary:
        //     The pending changes from more highly isolated transactions cannot be overwritten.
        Chaos = 5,
        //
        // Summary:
        //     A different isolation level than the one specified is being used, but the
        //     level cannot be determined. An exception is thrown if this value is set.
        Unspecified = 6,
    }

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

    // Summary:
    //     Contains additional information that specifies transaction behaviors.
    //     WB: This will never actually work. Kept as much of definition as needed to get this to compile
    public struct TransactionOptions
    {

        // Summary:
        //     Returns a value that indicates whether two System.Transactions.TransactionOptions
        //     instances are not equal.
        //
        // Parameters:
        //   x:
        //     The System.Transactions.TransactionOptions instance that is to the left of
        //     the equality operator.
        //
        //   y:
        //     The System.Transactions.TransactionOptions instance that is to the right
        //     of the equality operator.
        //
        // Returns:
        //     true if x and y are not equal; otherwise, false.
        //public static bool operator !=(TransactionOptions x, TransactionOptions y);
        //
        // Summary:
        //     Tests whether two specified System.Transactions.TransactionOptions instances
        //     are equivalent.
        //
        // Parameters:
        //   x:
        //     The System.Transactions.TransactionOptions instance that is to the left of
        //     the equality operator.
        //
        //   y:
        //     The System.Transactions.TransactionOptions instance that is to the right
        //     of the equality operator.
        //
        // Returns:
        //     true if x and y are equal; otherwise, false.
        //public static bool operator ==(TransactionOptions x, TransactionOptions y);

        // Summary:
        //     Gets or sets the isolation level of the transaction.
        //
        // Returns:
        //     A System.Transactions.IsolationLevel enumeration that specifies the isolation
        //     level of the transaction.
        public IsolationLevel IsolationLevel { get; set; }
        //
        // Summary:
        //     Gets or sets the timeout period for the transaction.
        //
        // Returns:
        //     A System.TimeSpan value that specifies the timeout period for the transaction.
        public TimeSpan Timeout { get; set; }

        // Summary:
        //     Determines whether this System.Transactions.TransactionOptions instance and
        //     the specified object are equal.
        //
        // Parameters:
        //   obj:
        //     The object to compare with this instance.
        //
        // Returns:
        //     true if obj and this System.Transactions.TransactionOptions instance are
        //     identical; otherwise, false.
        //public override bool Equals(object obj);
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A 32-bit signed integer hash code.
        //public override int GetHashCode();
    }

    // Summary:
    //     Makes a code block transactional. This class cannot be inherited.
    //     WB: Empty class. This will never actually work. Kept as much of definition as needed to get this to compile
    public sealed class TransactionScope : IDisposable
    {
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class.
        public TransactionScope() { }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     and sets the specified transaction as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        // public TransactionScope(Transaction transactionToUse);
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //public TransactionScope(TransactionScopeOption scopeOption);
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value, and sets the specified transaction as the
        //     ambient transaction, so that transactional work done inside the scope uses
        //     this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        // public TransactionScope(Transaction transactionToUse, TimeSpan scopeTimeout);
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value and requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        //public TransactionScope(TransactionScopeOption scopeOption, TimeSpan scopeTimeout);
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   transactionOptions:
        //     A System.Transactions.TransactionOptions structure that describes the transaction
        //     options to use if a new transaction is created. If an existing transaction
        //     is used, the timeout value in this parameter applies to the transaction scope.
        //     If that time expires before the scope is disposed, the transaction is aborted.
        public TransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value and COM+ interoperability requirements,
        //     and sets the specified transaction as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        //
        //   interopOption:
        //     An instance of the System.Transactions.EnterpriseServicesInteropOption enumeration
        //     that describes how the associated transaction interacts with COM+ transactions.
        //public TransactionScope(Transaction transactionToUse, TimeSpan scopeTimeout, EnterpriseServicesInteropOption interopOption);
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified scope and COM+ interoperability requirements, and transaction
        //     options.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   transactionOptions:
        //     A System.Transactions.TransactionOptions structure that describes the transaction
        //     options to use if a new transaction is created. If an existing transaction
        //     is used, the timeout value in this parameter applies to the transaction scope.
        //     If that time expires before the scope is disposed, the transaction is aborted.
        //
        //   interopOption:
        //     An instance of the System.Transactions.EnterpriseServicesInteropOption enumeration
        //     that describes how the associated transaction interacts with COM+ transactions.
        //public TransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, EnterpriseServicesInteropOption interopOption);

        // Summary:
        //     Indicates that all operations within the scope are completed successfully.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method has already been called once.
        public void Complete()
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Ends the transaction scope.
        //     NOT THE REAL DISPOSE! 
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    // Summary:
    //     Provides additional options for creating a transaction scope.
    public enum TransactionScopeOption
    {
        // Summary:
        //     A transaction is required by the scope. It uses an ambient transaction if
        //     one already exists. Otherwise, it creates a new transaction before entering
        //     the scope. This is the default value.
        Required = 0,
        //
        // Summary:
        //     A new transaction is always created for the scope.
        RequiresNew = 1,
        //
        // Summary:
        //     The ambient transaction context is suppressed when creating the scope. All
        //     operations within the scope are done without an ambient transaction context.
        Suppress = 2,
    }
}
