Для тестирования POST-запросов по адресу http://localhost:5000/report/user_statistics использовал консоль диспетчера пакетов;

PM> Invoke-RestMethod http://localhost:42296/report/user_statistics -Method POST -Body (@{user_id = "Имя_пользователя"; timeFrom = "Дата_с"; timeTo = "Дата_по"  } | ConvertTo-Json) -ContentType "application/json; charset=utf-8"

В качестве ответа на корректные исходные данные в консоль GUID пользователя;

Для тестирования GET-запросов по адресу http://localhost:42296/report/info можно использовал браузер;

http://localhost:42296/report/info?query='GUID_пользователя'
	
В качестве ответа на исходные данные в окне браузера должен отобразиться JSON-объект.

Ответ в браузере получал в зависимости от времени как в Тестовом задании.

