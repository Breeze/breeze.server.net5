namespace System.Data
{
#if DNXCORE50
    // Summary:
    //     Represents a transaction to be performed at a data source, and is implemented
    //     by .NET Framework data providers that access relational databases.
    public interface IDbTransaction : IDisposable
    {
        // Summary:
        //     Specifies the Connection object to associate with the transaction.
        //
        // Returns:
        //     The Connection object to associate with the transaction.
        IDbConnection Connection { get; }
        //
        // Summary:
        //     Specifies the System.Data.IsolationLevel for this transaction.
        //
        // Returns:
        //     The System.Data.IsolationLevel for this transaction. The default is ReadCommitted.
        IsolationLevel IsolationLevel { get; }

        // Summary:
        //     Commits the database transaction.
        //
        // Exceptions:
        //   System.Exception:
        //     An error occurred while trying to commit the transaction.
        //
        //   System.InvalidOperationException:
        //     The transaction has already been committed or rolled back.-or- The connection
        //     is broken.
        void Commit();
        //
        // Summary:
        //     Rolls back a transaction from a pending state.
        //
        // Exceptions:
        //   System.Exception:
        //     An error occurred while trying to commit the transaction.
        //
        //   System.InvalidOperationException:
        //     The transaction has already been committed or rolled back.-or- The connection
        //     is broken.
        void Rollback();
    }
#endif
}