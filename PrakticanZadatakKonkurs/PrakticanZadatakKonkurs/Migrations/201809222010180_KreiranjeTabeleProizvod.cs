namespace PrakticanZadatakKonkurs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KreiranjeTabeleProizvod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvod",
                c => new
                    {
                        ProizvodId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Opis = c.String(nullable: false),
                        Kategorija = c.String(nullable: false),
                        Proizvodjac = c.String(nullable: false),
                        Dobavljac = c.String(nullable: false),
                        Cena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proizvod");
        }
    }
}
