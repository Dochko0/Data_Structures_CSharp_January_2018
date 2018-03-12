using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Set<Transaction> byInsertion = new Set<Transaction>();
    private HashSet<Transaction> byOrder = new HashSet<Transaction>();
    //private List<Product> byChanging = new List<Product>();
    private Dictionary<int, Transaction> byId = new Dictionary<int, Transaction>();
    //private MultiDictionary<int, Dictionary<> byId = new MultiDictionary<int, Transaction>();

    public int Count => this.byId.Count;

    public void Add(Transaction tx)
    {
        List<Transaction> node = new List<Transaction>();
        if (!this.byId.ContainsKey(tx.Id))
        {
            this.byId.Add(tx.Id, tx);
            this.byInsertion.Add(tx);
            this.byOrder.Add(tx);
        }
        
        
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {

        if (this.byId.ContainsKey(id))
        {
            this.byId.Values.Where(x => x.Id==id).Select(x => x.Status = newStatus);
            //foreach (var item in this.byInsertion.Where(x => x.Id == id))
            //{
            //    item.Status = newStatus;
            //}
            
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public bool Contains(Transaction tx)
    {
        if (!this.byInsertion.Contains(tx))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool Contains(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        if (this.byId.Values.Where(x => x.Amount >= lo && x.Amount < hi)==null)
        {
            return null;
        }
        return this.byId.Values.Where(x => x.Amount >= lo && x.Amount < hi).OrderByDescending(x => x.Amount);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return this.byId.Values.OrderByDescending(x=>x.Amount).
            ThenBy(x => x.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        //return this.byId.Values.Where(x => x.Status.Equals(status));
        return null;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        //return this.byId.Values.Where(x => x.Status.Equals(status));
        return null;
    }

    public Transaction GetById(int id)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        Transaction transaction;
        var productExists = this.byId.TryGetValue(id, out transaction);
        return transaction;
        //return this.byId.Values.Where(x => x.Id);
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        //return this.byId.Values.Where(x => x.Equals(status));
        return null;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        return this.byId.Values.Where(x => x.Status.Equals(status)).OrderByDescending(x=>x.Id);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        return this.byId.Values.Where(x => x.Status.Equals(status) && x.Amount<amount).
            OrderByDescending(x => x.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        if (this.Count == 0)
            yield break;

        foreach (var item in this.byOrder)
        {
            yield return item;
        }
        
    }

    public void RemoveTransactionById(int id)
    {
        this.byId.Remove(id);
        //var a = this.byInsertion.FindAll(x=>x.Id==id);
        //this.byInsertion.Remove(a);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

