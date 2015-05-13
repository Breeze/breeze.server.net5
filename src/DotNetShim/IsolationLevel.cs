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
}
