namespace Sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddingTheLeftProductPiecesTriggers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                CREATE TRIGGER new_ware_purchase
                ON WarePurchases
                AFTER INSERT
                AS
                BEGIN
                    DECLARE @Id int, @Quantity int
                    SELECT @Id = ProductId from inserted
                    SELECT @Quantity = Quantity from inserted
                    UPDATE dbo.Products
                    SET PiecesLeft = PiecesLeft + @Quantity
                    FROM Products
                    WHERE Id = @Id
                END
                ");

            Sql(@"
                CREATE TRIGGER new_customer_order
                ON Orders
                AFTER INSERT
                AS
                BEGIN
                    DECLARE @Id int, @Quantity int
                    SELECT @Id = ProductId from inserted
                    SELECT @Quantity = Quantity from inserted
                    UPDATE Products
                    SET PiecesLeft = PiecesLeft - @Quantity
                    FROM Products
                    WHERE Id = @Id
                END
                ");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER new_ware_purchase");
            Sql("DROP TRIGGER new_customer_order");
        }
    }
}
