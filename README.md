<h2> 🐶 Bem vindo à Web API LovePetCare ⚕️ <h2>

<h5> ☞  Este projeto é uma WEBAPI de simulação de uma clínica veterinária fictícia, a <i>LovePetCare</i>.<h5>

<h5> ☞  Nesta aplicação o usuário poderá realizar o CRUD básico (criar, consultar, atualizar ou remover registros) das entidades existentes.<h5>
<hr>

<h3>  📓 Como utilizar esta aplicação<h3>

<h4><b>Clonando o projeto</b><h4>
<h5> ☞  No terminal de sua IDE clone o repositório do projeto<br>

<h4><b>Populando o banco de dados</b><h4>
<h5> ☞  Agora execute o seguinte comando:<h5>
<b><i> dotnet ef database update</i></b> (esse comando garante que a aplicação crie e realize a população do banco de dados, proporcionando uma experiência mais completa).

<h4><b>Iniciando a aplicação</b><h4>
<h5> ☞ No terminal execute o comando <b><i> dotnet watch run</i></b>, o programa será executado no browser padrão de seu computador.<h5>
<h5>* A aplicação funcionará perfeitamente pelo <i>Swagger</i>, mas caso haja a possibilidade/desejo de testar os endpoints de outra forma, com o projeto em execução há a possibilidade de fazer as requisições HTTP via <i>Postman</i><h5>

<h4><b>Informações sobre autenticação via JWT (JSON Web Token)</b><h4>
<h5> ☞ Após executar a aplicação, é necessária uma autenticação para que o usuário possa ter acesso aos endpoints (de acordo com o nível de acesso fornecido ao tipo de usuário - veterinários têm acesso a todos os recursos da aplicação, clientes têm acesso restrito a determinados endpoints)<h5>

<h4><b>Autenticando o usuário na prática</b><h4>
<h5> ☞ Via <i>Swagger</i>:<h5>
<h5> ☞ Acesse o endpoint "Logins" para autenticar o usuário. Após o população do banco de dados, a aplicação deverá ter informações de <b>05 clientes e 04 veterinários</b>, das quais utilizam-se os Emails e Senhas para acesso. A fim de facilitar o acesso, os dados de 02 usuários com permissões distintas estarão listados abaixo 👇<h5>

☞ Usuário Cliente (acesso restrito):<br>
Email: usuario@gft.com<br>
Senha: Gft@1234<br>
usuarioVet: false

☞ Usuário Veterinário (acesso a todos os recursos):<br>
Email: admin@1234<br>
Senha: Gft@1234<br>
usuarioVet: true

<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Logins.png">

<b>(Todos os usuários e dados são fictícios, não há qualquer informação sensível disponível para consulta)</b>

<h4>Recebendo o Token JWT<h4>
<h5> ☞ Após o preenchimento da requisição POST na controller "Logins", o usuário deverá receber um código alfanumérico, o Token JWT.<h5>
<h5> De posse do Token, o usuário poderá agir de duas formas distintas para ter acesso às funcionalidades do sistema, podendo ser via <i>Swagger</i> ou via <i>Postman</i>.<h5>

<h5><b> ☞ Via <i>Swagger</i>:</b><h5>
<h6>☞ Clicar no campo <i>"Authorize"</i> localizado na parte superior direita, e preenchendo da seguinte forma: "Bearer + Token JWT"<br>
ex.: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJlbWFpbCI6ImVyaWNrLWRhY3VuaGE3MEBtYXZleC5jb20uYnIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c2VyQ2xpZW50ZSIsImV4cCI6MTY1ODc4OTk5OCwiaXNzIjoiR2Z0UGV0Q2FyZSIsImF1ZCI6InVzdWFyaW9Mb2dhZG8ifQ.SsRFuRGZ2OCXrY6jg3hw-lt4Z1VR8BkPQzwGVkPeqA4<h6><br>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Authentication.png">

<h5><b> ☞ Via <i>Postman</i>:</b><h5>
<h6>Após acessar o endereço do localhost na barra de requisições, clicar na aba <i>"Authorization"</i> e no campo <i>"Type"</i> selecionar a opção <i>Bearer Token</i>, preenchendo em seguida o campo ao lado com o Token recebido anteriormente.<h6><br>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Postman.png">

<h5>Pronto! O acesso está liberado e a aplicação pode ser acessada sem problemas.<br>
Obs.: (A cada atualização de página ou reinicialização de aplicação há a necessidade de realizar novo login para obtenção de novo Token)<h5>
<hr>

<h3> 📌 Endpoints <h3>
<h4> 🐶 Animais <h4>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Animais.png">
<h5><i>Listar</i> - retorna todos os registros de animais do banco de dados com seus respectivos tutores<h5>
<h5><i>PesquisaId/{Id}</i> - retorna o registro do animal com o Id pesquisado com seu respectivo tutor<h5>
<h5><i>PesquisaNome/{Nome}</i> - retorna o registro do animal com o nome pesquisado com seu respectivo tutor<h5>
<h5><i>PesquisaRaca/{Raca}</i> - retorna todos os animais da raça pesquisada no banco de dados com seus respectivos tutores<h5>
<h5><i>Cadastrar</i> - cadastra um novo animal no banco de dados (deve ser associado a um tutor)<h5>
<h5><i>Atualizar</i> - atualiza o registro de um animal do banco de dados<h5>
<h5><i>Excluir/{Id}</i> - realiza a exclusão booleana de um registro de animal (inativa o registro, porém os dados permanecem no banco de dados)<h5>

<h4> 📋 Atendimentos <h4>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Atendimentos.png">
<h5><i>Listar</i> - retorna todos os registros de atendimentos do banco de dados<h5>
<h5><i>{Id}</i> - retorna o atendimento com o Id pesquisado<h5>
<h5><i>Animal/PesquisaId/{Id}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao Id do animal pesquisado<h5>
<h5><i>Animal/PesquisaNome/{Nome}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao nome do animal pesquisado<h5>
<h5><i>Animal/PesquisaRaca/{Raca}</i> - retorna o(s) registro(s) de atendimento(s) que contêm algum animal da raça pesquisada<h5>
<h5><i>Cliente/PesquisaCpf/{Cpf}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao CPF do cliente pesquisado<h5>
<h5><i>Cliente/PesquisaId/{Id}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao Id do cliente pesquisado<h5>
<h5><i>Cliente/PesquisaNome/{Nome}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao nome do cliente pesquisado<h5>
<h5><i>Veterinario/PesquisaId/{Id}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao Id do veterinário pesquisado<h5>
<h5><i>Veterinario/PesquisaNome/{Nome}</i> - retorna o(s) registro(s) de atendimento(s) atribuído(s) ao nome do veterinário pesquisado<h5>
<h5><i>Cadastrar</i> - cadastra um novo atendimento no banco de dados<h5>
<h5><i>Finalizar/{Id}</i> - finaliza um atendimento baseado no Id passado como parâmetro<h5>
<h5><i>Atualizar</i> - atualiza o registro de um atendimento do banco de dados<h5>
<h5><i>Excluir/{Id}</i> - realiza a exclusão booleana de um registro de atendimento (inativa o registro, porém os dados permanecem no banco de dados)<h5>

<h4> 👦🏻 Clientes <h4>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Clientes.png">
<h5><i>Listar</i> - retorna todos os registros de clientes do banco de dados<h5>
<h5><i>PesquisaNome/{Id}</i> - retorna o registro do cliente com o Id pesquisado<h5>
<h5><i>PesquisaNome/{Cpf}</i> - retorna o registro do cliente com o CPF pesquisado<h5>
<h5><i>PesquisaId/{Nome}</i> - retorna o registro do cliente com o nome pesquisado<h5>
<h5><i>Cadastrar</i> - cadastra um novo cliente no banco de dados<h5>
<h5><i>Atualizar</i> - atualiza o registro de um cliente do banco de dados<h5>
<h5><i>Excluir/{Id}</i> - realiza a exclusão booleana de um registro de cliente (inativa o registro, porém os dados permanecem no banco de dados)<h5>

<h4> 🔐 Logins <h4>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Logins.png">
<h5><i>Login</i> - realiza a autenticação do usuário (se válida, retorna o token JWT)<h5>

<h4> 🩺 Veterinarios <h4>
<img src="https://github.com/bruno89dev/VetAPI/blob/main/img/Veterinarios.png">
<h5><i>Listar</i> - retorna todos os registros de veterinários do banco de dados<h5>
<h5><i>PesquisaId/{Id}</i> - retorna o registro do veterinário com o Id pesquisado<h5>
<h5><i>PesquisaDocId/{DocId}</i> - retorna o registro do veterinário com o documento pesquisado<h5>
<h5><i>PesquisaNome/{Nome}</i> - retorna o registro do veterinário com o nome pesquisado<h5>
<h5><i>Cadastrar</i> - cadastra um novo veterinário no banco de dados<h5>
<h5><i>Atualizar</i> - atualiza o registro de um veterinário do banco de dados<h5>
<h5><i>Excluir/{Id}</i> - realiza a exclusão booleana de um registro de veterinário (inativa o registro, porém os dados permanecem no banco de dados)<h5>
<hr>

<h3> ⚙️ Essencial <h3>

<h5> ☞  Esta Web API utiliza algumas ferramentas essenciais, são elas:<h5><br>
<b><i> - IDE (recomenda-se utilizar Visual Studio Code)</b></i><br><br>
<b><i> - .NET (framework 5.0)</b></i><br><br>
<b><i> - Microsoft EntityFramework Core</b></i><br><br>
<b><i> - ASP.NET Core</b></i><br>
<hr>

<h3> 🛠 Ferramentas úteis <h5>
<b><i> - Postman</b></i>
<hr>

<h4> 🚀 Projeto desenvolvido por <i><a href="https://github.com/bruno89dev">Bruno Ferreira</a></i><h4>
