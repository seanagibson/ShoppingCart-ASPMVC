namespace MVCShoppingCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "SoldDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SoldDate", c => c.DateTime(nullable: false));
        }
    }
}
