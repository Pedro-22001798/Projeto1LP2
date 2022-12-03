# Projeto 1 - Linguages de Programação II 22/23
## Autoria
- Pedro Silva - 22001798
    - Elaboração do relatório
    - UI Unity
    - Código
    - Revisão de código
    - Documentação

## Legendas
### Legenda Tiles
![alt text](Images/Tiles.png)
### Legenda Recursos
![alt text](Images/Resources.png)

## Arquitetura de Solução
### Descrição de Solução
O programa inicia com uma consola que identifica todos os ficheiros com extensão ".map4x" dentro da pasta "map4xfiles" dentro do Ambiente de Trabalho do utilizador. De seguida, a aplicação `Program` coloca as opções disponíveis dentro de um *dropdown*, possibilitando ao jogador escolher qual mapa pretende que seja jogado.
Ao clicar no "*Start Game*" a aplicação lê todas as linhas dentro do ficheiro pretendido onde, identifica que a primeira linha representa as dimensões do mapa, colocando cada valor em variáveis (*rows* e *cols*). Para as restantes linhas, irá colocar o texto respetivo a cada linha dentro de uma variável, separando-a por *strings*. Desta forma a aplicação identifica o terreno pretendido e os recursos dentro do mesmo, até acabar a linha ou encontrar um comentário, quebrando o ciclo.
Dentro deste ciclo, caso o terreno pretendido tenha recursos, a aplicação irá criar um novo `Resource` que recebe o valor *string* do recurso, adicionando a uma lista para o terreno atual.
Caso a aplicação não identifique a primeira palavra como o inicio de um comentário, a mesma irá criar um novo `Tile` para cada linha válida, recebendo uma *string* correspondende ao tipo de terreno, bem como uma lista de recursos para o mesmo.
Finalizando o ciclo, a aplicação irá transportar a informação (*rows* e *cols*) para o `FillMap` que é responsável pela implementação do visual do mapa pretendido.

Dentro do projeto existem dois *scripts* responsáveis pelos tipos de terreno e recursos disponíveis, sendo eles, `TerrainType` e `ResourceType`.

Dentro do script responsável pelas variáveis de um terreno, o `Tile`, é possível encontrar um *IDictionary*, que recebe o valor em *string*, do ficheiro, e devolve o valor em `TerrainType`. Dentro do construtor, que recebe o valor *string* do terreno, bem como os recursos nele contidos, o mesmo atribui o valor `TerrainType` à variável inicializada anteriormente. De seguida, é iniciado um método que irá procurar pelo tipo de terreno, atribuindo os valores de *gold*, *food* e cor definidos no enunciado. Por fim, cria uma lista nova da anteriomente declarada, e, através de um ciclo, coloca todos os recursos recebidos pelo construitor dentro dessa lista.

O *script* `Resource` funciona da mesma forma, sendo que também contém um *IDictionary* para o valor *string* e o valor `ResourceType` correspondentes. A pricipal diferença está no construtor, que desta vez não precisa de uma lista de recursos. 

Dentro do `NewMap` podemos encontrar alguns métodos, responsáveis pela criação de uma matriz, utilizada no `Program`, bem como um método que devolve a informação `Tile` dentro das coordenadas estipuladas.

