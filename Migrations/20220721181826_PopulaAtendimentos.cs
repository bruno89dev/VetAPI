using Microsoft.EntityFrameworkCore.Migrations;

namespace GftPetCare.Migrations
{
    public partial class PopulaAtendimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO atendimentos(Id, DataDoAtendimento, VeterinarioId, AnimalId, TutorId, PesoAtual, AlturaEmCmAtual, Diagnostico, ObservacoesGerais, RegistroAtivo) VALUES (1, '2022-07-14 12:23:59', 2, 3, 2, 11.8, 32, 'Animal demonstra sinais de desconforto abdominal e perda de apetite.', 'Leve perda de peso proveniente de diminuição da alimentação, sinais vitais e exame clínico ok. Encaminhado para exames laboratoriais.', TRUE)");

            migrationBuilder.Sql("INSERT INTO atendimentos(Id, DataDoAtendimento, VeterinarioId, AnimalId, TutorId, PesoAtual, AlturaEmCmAtual, Diagnostico, ObservacoesGerais, RegistroAtivo) VALUES (2, '2022-07-15 14:44:51', 3, 5, 1, 12.9, 34.1, 'Exame clínico denota dermatite atópica. Tutor relata início de sintomas após dar banho no animal.', 'Pequenas feridas esparsas ao longo do corpo do paciente, com maior concentração em regiões dorsais devido ao prurido em excesso. Receitado Vetaglós Pomada 2x ao dia nas áreas afetadas durante 5 dias. Tutor orientado a retornar caso sintomas perdurem após o tratamento com medicação de uso tópico.', TRUE)");
            
            migrationBuilder.Sql("INSERT INTO atendimentos(Id, DataDoAtendimento, VeterinarioId, AnimalId, TutorId, PesoAtual, AlturaEmCmAtual, Diagnostico, ObservacoesGerais, RegistroAtivo) VALUES (3, '2022-07-17 10:02:11', 4, 7, 5, 4.2, 29, 'Animal com dificuldades de locomoção devido a desgaste ósseo em membro traseiro esquerdo, porção articular com cintura pélvica.', 'Solicitada radiografia e ultrassonografia. Receitado Rimadyl 25mg de 12/12 horas por 14 dias.', TRUE)");

            migrationBuilder.Sql("INSERT INTO atendimentos(Id, DataDoAtendimento, VeterinarioId, AnimalId, TutorId, PesoAtual, AlturaEmCmAtual, Diagnostico, ObservacoesGerais, RegistroAtivo) VALUES (4, '2022-07-19 17:12:13', 1, 4, 4, 25.9, 48.9, 'Paciente com placa bacteriana moderada em ambas as arcadas dentárias.', 'Realizada remoção de placa bacteriana. Recomendado ao tutor a aquisição de brinquedo mastigável a fim de evitar formação de nova placa. Exame clínico ok.', TRUE)");

            migrationBuilder.Sql("INSERT INTO atendimentos(Id, DataDoAtendimento, VeterinarioId, AnimalId, TutorId, PesoAtual, AlturaEmCmAtual, Diagnostico, ObservacoesGerais, RegistroAtivo) VALUES (5, '2022-07-21 09:47:59', 2, 1, 3, 7.1, 26.2, 'Animal sugere infecção otológica.', 'Sintomas claro de otite: animal virando a cabeça, cera com coloração anormal e odor sugestivo de infecção bacteriana. Receitado Aurivet (4 gotas na orelha afetada, 2x/dia por 15 dias). Tutor orientado a retornar caso sintomas não melhorem dentro dos primeiros 7 dias de tratamento.', TRUE)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM atendimentos");
        }
    }
}
