# 1. Problema industrial e objetivos

## 1.1 Contexto do cenário

Uma pequena unidade industrial utiliza equipamentos como motores
elétricos, bombas e ventiladores em suas operações. Durante o
funcionamento, esses equipamentos apresentam variáveis que podem indicar
mudanças de condição, como temperatura e vibração.

No cenário atual hipotético, essas informações não estão reunidas em um
único lugar. A equipe pode depender de inspeções manuais, anotações
dispersas ou da percepção do operador para notar mudanças de
funcionamento. Isso dificulta consultar o histórico, comparar medições e
identificar tendências antes que uma condição se agrave.

> **Nota:** este é um cenário de projeto proposto para desenvolvimento e
> demonstração. Não representa um diagnóstico validado de uma fábrica
> específica.

## 1.2 Declaração do problema

A equipe de manutenção e operação não dispõe de uma visão centralizada e
histórica das medições dos equipamentos monitorados. Por isso, pode ser
difícil perceber variações, priorizar verificações e documentar
ocorrências de forma consistente.

O sistema deverá centralizar dados de equipamentos e sensores,
apresentar medições ao longo do tempo e gerar alertas simples quando
valores ultrapassarem limites configurados.

## 1.3 Consequências que o sistema pretende ajudar a reduzir

-   Demora para perceber que uma medição ultrapassou um limite definido.
-   Falta de histórico acessível para apoiar inspeções.
-   Registros inconsistentes ou espalhados por diferentes ferramentas.
-   Dificuldade de visualizar quais equipamentos exigem atenção.
-   Falta de rastreabilidade básica sobre alertas e seu tratamento.

O sistema não promete eliminar falhas, evitar paradas ou prever defeitos
com precisão. Esses resultados exigiriam validação em ambiente real,
dados representativos e avaliação operacional.

## 1.4 Objetivo geral

Construir uma plataforma web para cadastrar equipamentos e sensores,
receber ou simular medições, consultar históricos e gerar alertas de
monitoramento, com possibilidade de adicionar análise de anomalias em
uma etapa posterior.

## 1.5 Objetivos específicos

1.  Manter um cadastro organizado de equipamentos.
2.  Vincular sensores a equipamentos.
3.  Registrar medições com valor, unidade e data/hora.
4.  Consultar medições e visualizar tendências.
5.  Aplicar limites configurados para gerar alertas.
6.  Permitir que usuários autorizados consultem e tratem alertas.
7.  Testar regras importantes de negócio automaticamente.
8.  Preparar a arquitetura para futuras integrações IoT, cloud e IA.

## 1.6 Usuários beneficiados

-   Técnicos de manutenção, que consultam medições e tratam alertas.
-   Operadores, que acompanham a condição dos equipamentos.
-   Gestores, que consultam indicadores e históricos.
-   Administradores, que configuram cadastros e acessos.

## 1.7 Indicadores de sucesso do MVP

O MVP será considerado funcional quando for possível:

-   Cadastrar e consultar equipamentos e sensores.
-   Registrar medições válidas e rejeitar dados inválidos.
-   Consultar o histórico de medições por sensor e período.
-   Gerar um alerta quando um limite configurado for ultrapassado.
-   Consultar e atualizar o status de um alerta conforme as permissões.
-   Executar testes automatizados das principais regras.
-   Demonstrar o fluxo completo com dados simulados.

## 1.8 Limites e segurança

A primeira versão será de **monitoramento e apoio à decisão**. Não
enviará comandos para ligar, desligar ou alterar o funcionamento de
máquinas. Não substituirá PLCs, intertravamentos, sistemas
instrumentados de segurança, procedimentos de bloqueio ou ferramentas
industriais certificadas.

Alertas são indicações para análise humana, não diagnósticos definitivos
de falha. Antes de qualquer uso operacional real, será necessário
realizar avaliação de segurança, confiabilidade, conectividade, proteção
de dados e adequação às normas aplicáveis.
