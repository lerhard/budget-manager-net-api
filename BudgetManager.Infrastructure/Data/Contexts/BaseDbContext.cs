using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BudgetManager.Infrastructure.Data.Contexts;

public class BaseDbContext: DbContext
{
   private IDbConnection _connection;
   private IDbTransaction _transaction;

   protected BaseDbContext(DbContextOptions options): base(options)
   {
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured && _connection != null)
      {
         optionsBuilder.UseNpgsql((NpgsqlConnection)_connection);
      }
   }
   
   public void SetConnection(IDbConnection connection)
   {
      _connection = connection;
   }
   
   public void SetTransaction(IDbTransaction transaction)
   {
      _transaction = transaction;
   }
   
   public bool isTransactionActive => _transaction != null;
}