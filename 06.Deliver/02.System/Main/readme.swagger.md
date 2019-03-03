# About # 

Using https://github.com/rbeauchamp/Swashbuckle.OData for the OData APi's '

Using OWIN middleware for the Httpconfiguration

Ensure Swagger is run after defining API Routes. so removed the assembly load and manually call register after routes have been stated.

TODO:
Get APiController working alongside OData Api's, currently only ODATA api's work

Removed as Swagger needs alot of external resources, unsure if adding a new Api would break it so for time being removed. 
Can Add back in  and check f12 on edge/chrome for the additonal resources needed
      <customHeaders>
        <add name="Content-Security-Policy" value="default-src https:; connect-src 'self' https://ajax.googleapis.com; script-src 'self' https://ajax.googleapis.com  'sha256-yz8EGXlVkTdxTCpTtHtqng7oE3bwX3orfonAmITU84M=' 'sha256-cn7D6uq/aK19vXkrZ5cEj9PpNLC8WV5LMyjsgfZRsP8='; style-src 'self' https://ajax.googleapis.com 'sha256-MZKTI0Eg1N13tshpFaVW65co/LeICXq4hyVx6GWVlK0=' 'sha256-LpfmXS+4ZtL2uPRZgkoR29Ghbxcfime/CsD/4w5VujE=' 'sha256-YJO/M9OgDKEBRKGqp4Zd07dzlagbB+qmKgThG52u/Mk='; img-src 'self'" />
      </customHeaders>