# Imobiliaria

Passo a passo para colocar em produção:
## Front-end:
1. alterar environments.ts para apontar para http://imob.runasp.net
2. compilar: ng build --configuration production
3. criar arquivo web.config:
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <rewrite>
      <rules>
        <rule name="Angular Routes" stopProcessing="true">
          <match url=".*" />
          <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
          </conditions>
          <action type="Rewrite" url="/index.html" />
        </rule>
      </rules>
    </rewrite>
  </system.webServer>
</configuration>
```
4. adicionar web.config no diretório wwwwroot
