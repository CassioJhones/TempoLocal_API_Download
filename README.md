# Tempo Local
> Programa Console para exibição de informações do tempo, temperatura e outros.

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
Para temperatura em **Celsius** use = métrica


