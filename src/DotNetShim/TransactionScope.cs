// Missing from ASP.NET 5 both DNX451 and DNXCore5
namespace System.Transactions
{
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
