<h3 align="left">Установка</h3>

Клонируйте репозиторий к себе на устройство: `git clone https://github.com/oneeightseven/.NET8-MinimalAPI-SurveyService.git`


Запустите docker-compose: `docker compose up --build`


<h3 align="left">Тестовые данные</h3>

База данных хранит в себе тестовые данные одного опроса.
Вы их можете протестировать перейдя по следующим ендпоинтам в постмане:

> `http://localhost/getQuestion/1/` Получение первого опроса и первого вопроса у опроса (первый параметр это id опроса, второй параметр необязательный - если он null, то вёрнется первый вопрос)

> `http://localhost/saveAnswer/1/1` Сохранение ответа на первый вопрос (первый параметр это interviewSession, второй параметр это id ответа) 

> `http://localhost/getQuestion/1/2`

> `http://localhost/saveAnswer/1/4`

> `http://localhost/getQuestion/1/3` 

> `http://localhost/saveAnswer/1/7`

После завершения теста вернется строка "Test completed" 

Так-же вы можете перейти в swagger и протестировать в нём:

> `http://localhost/swagger/index.html`


<h3 align="left">Что можно улучшить/изменить</h3>

Можно добавить кэширование результатов запросов. 
Например: 
	1. Запрос на получение опроса
	2. Запрос на получение вопроса
	3. Запрос на получение ответов на вопрос
	4. Запрос на получение ответа (Преимущественно стоит закэшировать его)
	5. Запрос на получение максимального id вопроса у опроса.
	
Вместо параметра interviewSession можно передавать полезную нагрузку пользователя
Например: 
	1. userName/email
	
Изменить входные параметры ендпоинта saveQuestion:
Например:
	1. Увеличить кол-во входных параметров, добавив (surveyId, questionId) это позволит уменьшить кол-во запросов к бд, но может привести к заполнению таблицы невалидными данными. 
