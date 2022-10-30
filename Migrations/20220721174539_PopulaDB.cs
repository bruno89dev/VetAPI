using Microsoft.EntityFrameworkCore.Migrations;

namespace GftPetCare.Migrations
{
    public partial class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (1, 'Erick Eduardo Renato da Cunha', '037.589.387-32', 'erick-dacunha70@mavex.com.br', 'qUAEgCuHx8', TRUE)");

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (2, 'Alice Andreia Analu da Rosa', '272.669.934-07', 'alice_andreia_darosa@evolut.com', 'JBl0Fr4cmy', TRUE)");

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (3, 'Sueli Marlene Natália da Rocha', '986.538.505-89', 'mario-brito91@anac.gov.br', 'Qk4EjpqdBU', TRUE)");

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (4, 'Mário Kaique Cauã Brito', '037.589.387-32', 'erick-dacunha70@mavex.com.br', 'qUAEgCuHx8', TRUE)");

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (5, 'Marcos Vinicius Fernandes', '466.118.416-52', 'mv.fernandes@novadelivery.com.br', 'xUdgiXkfPz', TRUE)");

            migrationBuilder.Sql("INSERT INTO clientes(Id, Nome, Cpf, Email, Senha, RegistroAtivo) VALUES (6, 'UserGFT', '111.111.111-11', 'usuario@gft.com', 'Gft@1234', TRUE)");

            /////////////////////////////////////////////

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (1, 'Xuxa', 3, 'Lhasa Apso', 'Fêmea', 5.9, 26.2, TRUE, 2015, 7)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (2, 'Bob', 2, 'Pinscher', 'Macho', 4.3, 23.4, TRUE, 2017, 5)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (3, 'Pretinha', 2, 'SRD', 'Fêmea', 12.7, 32, TRUE, 2011, 11)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (4, 'Thor', 4, 'Pitbull', 'Macho', 25.4, 48.9, TRUE, 2020, 2)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (5, 'Marujo', 1, 'Bulldog Francês', 'Macho', 12.7, 34.1, TRUE, 2016, 6)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (6, 'Caramelo', 5, 'SRD', 'Macho', 13.8, 34.5, TRUE, 2019, 3)");

            migrationBuilder.Sql("INSERT INTO animais(Id, Nome, TutorId, Raca, Genero, Peso, AlturaEmCm, RegistroAtivo, AnoDeNascimento, Idade) VALUES (7, 'Meg', 5, 'Coton de Tulear', 'Fêmea', 4.7, 29.2, TRUE, 2009, 13)");

            /////////////////////////////////////////////

            migrationBuilder.Sql("INSERT INTO veterinarios(Id, Nome, DocIdentificacao, Email, Senha, Especialidade, RegistroAtivo) VALUES (1, 'Elias Sérgio Kauê Ramos', '033.991.439-40', 'elias.sergio.ramos@gftpetcare.com.br', 'tzpq5fPEPg', 'Odontologia Veterinária', TRUE)");

            migrationBuilder.Sql("INSERT INTO veterinarios(Id, Nome, DocIdentificacao, Email, Senha, Especialidade, RegistroAtivo) VALUES (2, 'Heloise Caroline Benedita Almeida', '205.657.184-60', 'heloise_caroline_almeida@gftpetcare.com.br', 'S67M5yLM7m', 'Clínica Geral', TRUE)");

            migrationBuilder.Sql("INSERT INTO veterinarios(Id, Nome, DocIdentificacao, Email, Senha, Especialidade, RegistroAtivo) VALUES (3, 'Alessandra Giovanna Galvão', '959.792.363-76', 'alessandragiovannagalvao@gftpetcare.com.br', 'UoR7jqerF9', 'Dermatologia Veterinária', TRUE)");

            migrationBuilder.Sql("INSERT INTO veterinarios(Id, Nome, DocIdentificacao, Email, Senha, Especialidade, RegistroAtivo) VALUES (4, 'Lúcia Josefa Pereira', '053.154.104-55', 'lucia_josefa_pereira@gftpetcare.com.br', 'MyTtMRmInA', 'Fisioterapia Veterinária', TRUE)");

            migrationBuilder.Sql("INSERT INTO veterinarios(Id, Nome, DocIdentificacao, Email, Senha, Especialidade, RegistroAtivo) VALUES (5, 'VetGFT', '222.222.222-22', 'admin@gft.com', 'Gft@1234', 'Veterinário Admin', TRUE)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM clientes");
            migrationBuilder.Sql("DELETE FROM animais");
            migrationBuilder.Sql("DELETE FROM veterinarios");
        }
    }
}