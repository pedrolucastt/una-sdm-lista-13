# una-sdm-lista-13

Respondendo o Desafio de Sistemas Distribuídos:
O Thread.Sleep(2000) (2 segundos) poderia fazer com que o usuário do Mobile ache que a tela travou por causa do tempo. Mas também poderia deixar a requisição mais realista, simulando uma requisição via satélite.

4. Pensamento Crítico (README.md):
Para garantir a integridade das reservas em um sistema de escala global, a escolha entre Pessimistic Locking e Optimistic Concurrency depende da experiência do usuário desejada. O Pessimistic Locking é ideal para evitar conflitos antes que ocorram, bloqueando o registro assim que o usuário inicia a seleção, garantindo que o assento esteja reservado durante o checkout. Já o Optimistic Concurrency é mais eficiente para sistemas de alto tráfego, pois não bloqueia o banco de dados, ele utiliza uma versão ou token de controle que valida, no momento da gravação, se os dados foram alterados por outro processo desde a última leitura.