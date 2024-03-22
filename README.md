# Tempo Local  
![Static Badge](https://img.shields.io/badge/Status-Finalizado-green?style=for-the-badge)
![VISUAL STUDIO](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![DOTNET](https://img.shields.io/badge/.NET-Version_8.0-gray?style=for-the-badge&labelColor=%23512BD4)
![GitHub repo size](https://img.shields.io/github/repo-size/CassioJhones/TempoLocal_API_Download?style=for-the-badge&label=Project%20Size&labelColor=%23512BD4)
> Programa Console para exibição de informações do tempo, temperatura e outros.

ATUALIZAÇÃO: https://github.com/CassioJhones/Weather_WPF

# Demonstração
<img src="https://github.com/CassioJhones/TempoLocal_API_Download/assets/56178855/61381563-823f-408b-a706-1982e0652867" width="350px" alt="DEMONSTRAÇÃO">

---

## Documentação de como foi usada a API
https://openweathermap.org/api

#### Chamada da API

```https
https://api.openweathermap.org/data/2.5/weather?q={LOCAL}&lang={IDIOMA}&appid={CHAVE}&units={UNIDADE}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
|`q` | `obrigatorio` | Nome da cidade, pais, local |
|`appid` | `obrigatorio` | Sua chave de API exclusiva  |
|`mode` | `opcional` | Formato de resposta. Os valores possíveis são `XML` e `HTML`. O formato `JSON` é padrão |
|`units` | `opcional` | Unidades de medida. `standard`, `metric` e `imperial`. `standard` é aplicadas por padrão |
|`lang` | `opcional` | Você pode usar este parâmetro para obter a saída em seu idioma |

A temperatura está disponível em unidades Fahrenheit, Celsius e Kelvin.<br/>
Para temperatura em **Fahrenheit** use = imperial<br/>
Para temperatura em **Celsius** use = metric
