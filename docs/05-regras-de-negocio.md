# 5. Regras de negócio iniciais

As regras abaixo devem ser implementadas no backend e protegidas por
testes automatizados. Elas podem ser refinadas quando o modelo de dados
e os casos de uso forem detalhados.

  -----------------------------------------------------------------------
  ID                                  Regra
  ----------------------------------- -----------------------------------
  RN01                                O código de um equipamento deve ser
                                      único.

  RN02                                Equipamento e sensor devem possuir
                                      identificadores únicos.

  RN03                                Um sensor deve estar associado a um
                                      equipamento existente.

  RN04                                Uma medição deve referenciar um
                                      sensor existente.

  RN05                                Toda medição deve conter valor
                                      numérico válido, unidade coerente e
                                      data/hora.

  RN06                                Uma medição recebida não deve ser
                                      editada manualmente no fluxo
                                      normal; correções futuras deverão
                                      ser auditáveis.

  RN07                                Os limites de alerta devem ser
                                      coerentes com a unidade e o tipo do
                                      sensor.

  RN08                                Se o limite máximo estiver
                                      configurado e a medição excedê-lo,
                                      deve ser avaliada a criação de
                                      alerta.

  RN09                                Se o limite mínimo estiver
                                      configurado e a medição ficar
                                      abaixo dele, deve ser avaliada a
                                      criação de alerta.

  RN10                                A política de deduplicação deve
                                      evitar abrir um novo alerta
                                      idêntico para cada medição
                                      consecutiva fora do limite. A
                                      janela e a chave de deduplicação
                                      serão definidas na implementação.

  RN11                                Alertas devem possuir status
                                      explícito, por exemplo: Aberto, Em
                                      atendimento e Resolvido.

  RN12                                Apenas perfis autorizados podem
                                      alterar o status de um alerta.

  RN13                                Desativar um equipamento ou sensor
                                      não deve apagar automaticamente seu
                                      histórico.

  RN14                                Datas devem ser armazenadas de
                                      forma consistente,
                                      preferencialmente em UTC, e
                                      exibidas no fuso horário apropriado
                                      na interface.

  RN15                                Mensagens de dispositivos devem ser
                                      validadas antes de persistir os
                                      dados.

  RN16                                Se MQTT for implementado, uma
                                      identificação de mensagem poderá
                                      ser usada para reduzir
                                      processamento duplicado.

  RN17                                O resultado de IA deve ser tratado
                                      como indicador de possível
                                      anomalia, não como certeza de
                                      falha.

  RN18                                A plataforma não enviará comandos
                                      para operar máquinas no escopo
                                      atual.
  -----------------------------------------------------------------------

## Decisões necessárias antes da implementação dos alertas

1.  O alerta será criado por toda medição fora do limite ou após um
    número de ocorrências consecutivas?
2.  Quando uma nova medição voltar ao intervalo normal, o alerta será
    resolvido automaticamente ou continuará aguardando uma ação humana?
3.  Como severidade (informativo, atenção, crítico) será definida?
4.  Qual será a regra de deduplicação e quando um alerta já aberto
    poderá ser atualizado?
5.  Quais campos e eventos devem compor a auditoria?

Para a primeira implementação, mantenha a regra simples, documentada e
coberta por testes. Não classifique limites demonstrativos como limites
industriais seguros sem validação técnica.
