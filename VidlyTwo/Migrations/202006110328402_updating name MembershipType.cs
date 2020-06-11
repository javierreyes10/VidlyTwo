namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingnameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set name = 'Free' WHERE ID = 1");
            Sql("UPDATE MembershipTypes set name = 'Monthly' WHERE ID = 2");
            Sql("UPDATE MembershipTypes set name = 'Quarterly' WHERE ID = 3");
            Sql("UPDATE MembershipTypes set name = 'Annual' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
