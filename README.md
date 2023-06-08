# Oefening 5 : ADO.Net CRUD op 2 tabellen  
  
Deze keer schrijven we een app die kachels beheert.  We verkopen verschillende soorten kachels : houtkachels, pelletkachels, kolenkachels ...  
We maken deze keer terug zelf de database aan :   
  * Databasenaam = **ScalaAdovb5**  
  * Tabellen : 
    * **Kachels**  
      * **Id** : nvarchar(50), primary key  
      * **SoortId : nvarchar(50), vereist, verwijst naar de PK van de tabel **Soorten**  
      * **Merk** : nvarchar(50), vereist  
      * **Serie** : nvarchar(50), vereist  
      * **Prijs** : decimal(18,2), vereist 
    * **Soorten**  
      * **Id** : nvarchar(50), primary key   
      * **Soortnaam : nvarchar(50), vereist  
      
Als je de starterscode binnenhaalt, dan ga je merken dat er al heel wat code aanwezig is.  
