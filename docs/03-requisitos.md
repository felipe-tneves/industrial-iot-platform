# 3. Requisitos funcionais e não funcionais

## 3.1 Convenções

-   **RF**: requisito funcional --- comportamento que o sistema deve
    oferecer.
-   **RNF**: requisito não funcional --- qualidade, restrição ou
    condição de operação.
-   **Prioridade MVP**: Obrigatório, Importante ou Futuro.
-   **Critério de aceite**: condição verificável para considerar o
    requisito atendido.

Os requisitos descrevem o comportamento esperado. A tecnologia e a
arquitetura podem evoluir desde que os critérios sejam mantidos ou
formalmente revisados.

## 3.2 Requisitos funcionais

  -------------------------------------------------------------------------------
  ID                Requisito         Prioridade          Critério de aceite
  ----------------- ----------------- ------------------- -----------------------
  RF01              Cadastrar         Obrigatório         Um equipamento válido é
                    equipamento com                       salvo; código duplicado
                    nome, código                          é rejeitado com
                    único,                                mensagem clara.
                    localização e                         
                    status.                               

  RF02              Consultar, editar Obrigatório         Usuário autorizado
                    e desativar                           consegue consultar e
                    equipamentos.                         alterar dados;
                                                          equipamento desativado
                                                          não aparece como ativo.

  RF03              Cadastrar sensor  Obrigatório         Sensor só é salvo se o
                    vinculado a um                        equipamento associado
                    equipamento, com                      existir.
                    tipo, unidade e                       
                    status.                               

  RF04              Consultar, editar Obrigatório         As operações respeitam
                    e desativar                           as permissões e
                    sensores.                             preservam a integridade
                                                          dos vínculos.

  RF05              Registrar uma     Obrigatório         Medição válida é
                    medição contendo                      armazenada com
                    sensor, valor,                        referência ao sensor
                    unidade e                             correto.
                    data/hora.                            

  RF06              Validar dados     Obrigatório         Mensagens incompletas,
                    recebidos.                            valores inválidos ou
                                                          referências
                                                          inexistentes são
                                                          rejeitados e
                                                          registrados de forma
                                                          apropriada.

  RF07              Consultar         Obrigatório         A resposta retorna
                    medições por                          apenas medições do
                    sensor e                              sensor e período
                    intervalo de                          solicitados, em ordem
                    tempo.                                cronológica definida
                                                          pela API.

  RF08              Configurar        Obrigatório         Limites válidos podem
                    limites mínimo                        ser salvos por sensor;
                    e/ou máximo para                      valores incoerentes são
                    gerar alertas.                        rejeitados.

  RF09              Gerar alerta      Obrigatório         Uma medição acima do
                    quando uma                            máximo ou abaixo do
                    medição                               mínimo aplicável gera
                    ultrapassar o                         alerta conforme a regra
                    limite                                definida.
                    configurado.                          

  RF10              Consultar alertas Obrigatório         Os filtros retornam
                    e filtrar por                         apenas os alertas
                    status,                               correspondentes.
                    severidade,                           
                    equipamento e                         
                    período.                              

  RF11              Alterar o status  Obrigatório         Usuário autorizado pode
                    de um alerta.                         mudar o status
                                                          permitido e a alteração
                                                          fica registrada.

  RF12              Exibir resumo dos Importante          Dashboard apresenta
                    equipamentos e                        contagens consistentes
                    alertas no                            com os dados
                    dashboard.                            armazenados.

  RF13              Disponibilizar    Obrigatório         Endpoints e modelos
                    documentação dos                      principais podem ser
                    endpoints da API.                     explorados por
                                                          documentação OpenAPI em
                                                          ambiente de
                                                          desenvolvimento.

  RF14              Autenticar        Importante no       Chamadas sem credencial
                    usuários e        primeiro ciclo;     válida são bloqueadas
                    autorizar         obrigatório antes   nos endpoints
                    operações         de exposição        protegidos e ações não
                    conforme perfil.  pública             autorizadas retornam
                                                          erro apropriado.

  RF15              Receber medições  Futuro              Um
                    por MQTT.                             dispositivo/simulador
                                                          publica uma mensagem
                                                          válida e o sistema a
                                                          processa sem duplicação
                                                          indevida.

  RF16              Exibir gráficos e Futuro              Usuário visualiza série
                    filtros no                            temporal e pode filtrar
                    frontend web.                         o período.

  RF17              Detectar          Futuro              O serviço retorna um
                    possíveis                             indicador de anomalia
                    anomalias por                         acompanhado de
                    análise                               método/versão e
                    estatística ou                        resultado
                    modelo de IA.                         interpretável.

  RF18              Registrar trilha  Importante/Futuro   Ações definidas são
                    de auditoria de                       registradas com
                    ações relevantes.                     usuário, ação e
                                                          data/hora, sem expor
                                                          segredos.
  -------------------------------------------------------------------------------

## 3.3 Requisitos não funcionais

  ---------------------------------------------------------------------------
  ID                Requisito          Prioridade        Critério de aceite
  ----------------- ------------------ ----------------- --------------------
  RNF01             Manutenibilidade   Obrigatório       Código organizado
                                                         por
                                                         responsabilidades,
                                                         nomes consistentes e
                                                         instruções de
                                                         execução
                                                         documentadas.

  RNF02             Testabilidade      Obrigatório       Regras críticas
                                                         possuem testes
                                                         automatizados
                                                         executáveis
                                                         localmente.

  RNF03             Integridade dos    Obrigatório       Chaves,
                    dados                                relacionamentos e
                                                         restrições impedem
                                                         referências
                                                         inválidas e códigos
                                                         de equipamento
                                                         duplicados.

  RNF04             Segurança de       Obrigatório       Senhas armazenadas
                    credenciais                          com algoritmo de
                                                         hash apropriado;
                                                         segredos ficam fora
                                                         do código-fonte.

  RNF05             Autorização no     Obrigatório antes Cada operação
                    servidor           de exposição      protegida valida
                                       pública           permissão no
                                                         backend.

  RNF06             Validação de       Obrigatório       Entradas inválidas
                    entrada                              não causam falha não
                                                         tratada nem
                                                         persistência de
                                                         dados incorretos.

  RNF07             Observabilidade    Importante        Erros e eventos
                                                         relevantes são
                                                         registrados sem
                                                         gravar senhas,
                                                         tokens ou dados
                                                         sensíveis
                                                         desnecessários.

  RNF08             Desempenho         Meta inicial      Em ambiente local de
                                                         demonstração,
                                                         consultas comuns
                                                         respondem em até 2
                                                         segundos com até 10
                                                         mil medições de
                                                         teste, salvo
                                                         operações
                                                         explicitamente
                                                         pesadas.

  RNF09             Disponibilidade    Futuro            Metas de
                                                         disponibilidade
                                                         serão definidas
                                                         antes de qualquer
                                                         implantação
                                                         operacional. Não há
                                                         SLA no MVP.

  RNF10             Compatibilidade de Futuro            Dashboard utilizável
                    interface                            em versões atuais de
                                                         navegadores desktop;
                                                         suporte móvel será
                                                         validado quando o
                                                         frontend for
                                                         implementado.

  RNF11             Implantação        Importante        Passos de
                    reproduzível                         configuração e
                                                         execução são
                                                         documentados; Docker
                                                         será adotado em
                                                         etapa posterior.

  RNF12             Backup e           Futuro            Antes de uso
                    recuperação                          operacional,
                                                         existirão política
                                                         de backup e teste
                                                         documentado de
                                                         restauração.

  RNF13             Escalabilidade     Futuro            Arquitetura permite
                                                         avaliar ingestão e
                                                         volume maiores;
                                                         limites reais serão
                                                         medidos, não
                                                         presumidos.

  RNF14             Segurança          Obrigatório       O MVP não comanda
                    industrial                           máquinas nem
                                                         substitui sistemas
                                                         de segurança,
                                                         intertravamentos ou
                                                         controles
                                                         industriais
                                                         certificados.

  RNF15             Privacidade e      Obrigatório       São armazenados
                    minimização                          apenas dados de
                                                         usuário necessários
                                                         ao funcionamento e à
                                                         auditoria prevista.
  ---------------------------------------------------------------------------

## 3.4 Regras de erro da API

-   `400 Bad Request`: entrada inválida ou regra de validação não
    atendida.
-   `401 Unauthorized`: ausência de autenticação válida em endpoint
    protegido.
-   `403 Forbidden`: usuário autenticado sem permissão.
-   `404 Not Found`: recurso não encontrado.
-   `409 Conflict`: conflito de unicidade ou estado, quando aplicável.
-   `500 Internal Server Error`: falha inesperada, sem expor detalhes
    internos ao cliente.

Os códigos devem ser aplicados de maneira consistente e acompanhados de
mensagens úteis que não revelem informações sensíveis.

## 3.5 Fora dos requisitos iniciais

Não fazem parte do MVP: controle remoto de máquinas, manutenção
preditiva comprovada, integração com PLC/SCADA de produção, aplicativo
móvel nativo, cobrança/multitenancy e garantias de alta disponibilidade.
