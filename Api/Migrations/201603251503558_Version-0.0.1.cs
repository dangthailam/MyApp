namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 320),
                        UserName = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        DoB = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserEntities");
        }
    }
}
