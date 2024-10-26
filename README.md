# Design Patterns em C#

## O que são Design Patterns?

**Design Patterns** são soluções recorrentes e documentadas para problemas comuns encontrados no desenvolvimento de software. Eles não são soluções prontas para aplicar diretamente no código, mas sim guias ou modelos para resolver problemas recorrentes de design de sistemas de forma eficiente e reutilizável.

Esses padrões foram formalizados e popularizados pelos autores conhecidos como "Gang of Four" (GoF) no livro **"Design Patterns: Elements of Reusable Object-Oriented Software"**. Design Patterns são amplamente usados para melhorar a legibilidade, flexibilidade e manutenção do código.

## Para que servem?

Os Design Patterns ajudam a:

- **Facilitar a reutilização** de soluções para problemas comuns.
- **Melhorar a manutenibilidade** do código, tornando-o mais fácil de entender, estender e modificar.
- **Aumentar a flexibilidade** de sistemas ao permitir que o comportamento seja alterado de forma estruturada.
- **Promover boas práticas** no desenvolvimento de software, como a separação de responsabilidades e o princípio do "aberto para extensão, fechado para modificação" (OCP).

## Tipos de Design Patterns

Os Design Patterns são geralmente classificados em três categorias principais:

### 1. Behavioral Patterns (Padrões Comportamentais)
Esses padrões focam na interação e comunicação entre objetos, facilitando o fluxo de controle entre eles.

- **[Strategy](#padrão-strategy)**: Define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. 
- **[Observer](#padrão-observer)**: Define uma dependência um-para-muitos entre objetos, onde quando um objeto muda, seus dependentes são notificados.
- **[Command](#padrão-command)**: Encapsula uma solicitação como um objeto, permitindo parametrizar filas de execução e logs.
- **[Iterator](#padrão-iterator)**: Fornece uma maneira de acessar sequencialmente os elementos de uma coleção sem expor sua implementação subjacente.
- **Mediator**: Define um objeto intermediário que encapsula como um conjunto de objetos interage.
- **Memento**: Captura e restaura o estado interno de um objeto sem violar seu encapsulamento.
- **State**: Permite que um objeto altere seu comportamento quando seu estado interno muda.
- **Template Method**: Define o esqueleto de um algoritmo, delegando alguns passos para subclasses.
- **Visitor**: Permite adicionar novas operações a uma estrutura de objetos sem modificar as classes que a compõem.
- **[Chain of Responsibility](#padrão-chain-of-responsability)**: Passa uma solicitação por uma cadeia de manipuladores até que ela seja processada.
- **[Interpreter](#padrão-interpreter)**: Avalia e executa uma linguagem ou expressão com base em uma gramática definida.

### 2. Creational Patterns (Padrões de Criação)
Esses padrões fornecem maneiras de instanciar objetos, controlando a criação de instâncias para torná-la mais flexível.

- **Singleton**: Garante que uma classe tenha apenas uma instância e fornece um ponto global de acesso a ela.
- **Factory Method**: Define uma interface para criar objetos, mas deixa que subclasses decidam quais classes concretas instanciar.
- **Abstract Factory**: Cria famílias de objetos relacionados sem especificar suas classes concretas.
- **Builder**: Constrói objetos complexos passo a passo.
- **Prototype**: Cria novos objetos copiando uma instância existente (protótipo).

### 3. Structural Patterns (Padrões Estruturais)
Esses padrões tratam da composição de classes e objetos para formar estruturas maiores e mais eficientes.

- **Adapter**: Converte a interface de uma classe em outra que o cliente espera.
- **Bridge**: Desacopla uma abstração da sua implementação, permitindo que ambas variem independentemente.
- **Composite**: Composições de objetos em estruturas de árvore para representar hierarquias do tipo parte-todo.
- **Decorator**: Adiciona responsabilidades adicionais a um objeto dinamicamente.
- **Facade**: Fornece uma interface simplificada para um conjunto complexo de classes ou subsistemas.
- **Flyweight**: Minimiza o uso de memória compartilhando o máximo de dados possível com objetos semelhantes.
- **Proxy**: Fornece um substituto ou lugar para acessar outro objeto, controlando o acesso a ele.

## Objetivo do Projeto

Este repositório visa implementar os principais **Design Patterns** em C#, com exemplos práticos e bem documentados, seguindo as boas práticas de desenvolvimento orientado a objetos. Cada padrão de projeto terá uma implementação própria com testes unitários associados para validar o seu comportamento.

## Design Patterns Implementados

### 1. Behavioral Patterns (Padrões Comportamentais)
   - StrategyPattern.cs (Padrão Strategy) ✔️
   - ObserverPattern.cs (Padrão Observer) ✔️
   - CommandPattern.cs (Padrão Command) ✔️
   - IteratorPattern.cs (Padrão Iterator) ✔️
   - MediatorPattern.cs (Padrão Mediator)
   - MementoPattern.cs (Padrão Memento)
   - StatePattern.cs (Padrão State)
   - TemplateMethodPattern.cs (Padrão Template Method)
   - VisitorPattern.cs (Padrão Visitor)
   - ChainOfResponsibilityPattern.cs (Padrão Chain of Responsibility) ✔️
   - InterpreterPattern.cs (Padrão Interpreter) ✔️

### 2. Creational Patterns (Padrões de Criação)
   - SingletonPattern.cs (Padrão Singleton)
   - FactoryMethodPattern.cs (Padrão Factory Method)
   - AbstractFactoryPattern.cs (Padrão Abstract Factory)
   - BuilderPattern.cs (Padrão Builder)
   - PrototypePattern.cs (Padrão Prototype)

### 3. Structural Patterns (Padrões Estruturais)
   - AdapterPattern.cs (Padrão Adapter)
   - BridgePattern.cs (Padrão Bridge)
   - CompositePattern.cs (Padrão Composite)
   - DecoratorPattern.cs (Padrão Decorator)
   - FacadePattern.cs (Padrão Facade)
   - FlyweightPattern.cs (Padrão Flyweight)
   - ProxyPattern.cs (Padrão Proxy)

[Voltar ao topo](#)
## Padrão Strategy

### O que é o Strategy Pattern?

O **Strategy Pattern** (Padrão de Estratégia) é um padrão comportamental que permite definir uma família de algoritmos, encapsulá-los e torná-los intercambiáveis. Ele permite que o comportamento de um objeto mude independentemente dos clientes que o utilizam, oferecendo uma forma flexível e extensível de definir diferentes comportamentos para um mesmo objeto.

Em vez de implementar diretamente o comportamento desejado dentro de uma classe, o Strategy Pattern utiliza **composição**, onde uma interface define o método esperado para a estratégia, e classes concretas implementam diferentes variações desse comportamento.

### Objetivo

O objetivo principal do Strategy Pattern é permitir que o comportamento de uma classe mude dinamicamente sem precisar modificar o código-fonte. Isso é útil em situações onde várias variações de um algoritmo ou lógica de negócios precisam ser aplicadas, permitindo que o código seja modular e fácil de estender.

### Estrutura

O **Strategy Pattern** segue uma estrutura simples composta por:

- **Interface de Estratégia**: Define a assinatura do método que todas as estratégias concretas devem implementar.
- **Estratégias Concretas**: Implementações específicas da interface de estratégia, oferecendo diferentes comportamentos que podem ser aplicados no contexto.
- **Contexto**: A classe que utiliza a estratégia para realizar uma tarefa. O contexto pode alterar a estratégia dinamicamente, permitindo a mudança de comportamento em tempo de execução.

### Vantagens do Strategy Pattern

1. **Aberto para Extensão, Fechado para Modificação**: O Strategy Pattern segue o princípio SOLID de que classes devem ser abertas para extensão, mas fechadas para modificação. Isso significa que novas estratégias podem ser adicionadas sem a necessidade de alterar o código existente.

2. **Fácil de Manter e Testar**: Como cada algoritmo (ou estratégia) é isolado em sua própria classe, o código é mais fácil de manter e os testes podem ser escritos de forma independente para cada estratégia.

3. **Flexibilidade**: O contexto pode alterar a estratégia em tempo de execução, oferecendo flexibilidade para situações onde o comportamento do sistema precisa mudar dinamicamente, sem a necessidade de condicionar lógicas internas.

### Quando Usar?

Use o **Strategy Pattern** quando:

- Você tem várias variações de um algoritmo e deseja evitar o uso de condicionais complexas no código.
- O comportamento de um objeto precisa mudar em tempo de execução de forma fluida e estruturada.
- Você deseja isolar a lógica de diferentes algoritmos em classes separadas, facilitando a manutenção e os testes de cada um de forma independente.

O **Strategy Pattern** é ideal para cenários onde múltiplas abordagens ou comportamentos podem ser aplicados a um objeto, proporcionando flexibilidade, modularidade e manutenção simplificada.

[Voltar ao topo](#)

## Padrão Observer

### O que é o Observer Pattern?

O **Observer Pattern** (Padrão de Observador) é um padrão comportamental que define uma dependência de um-para-muitos entre objetos. Isso significa que, quando o estado de um objeto muda, todos os seus dependentes (observadores) são notificados e atualizados automaticamente. Ele é ideal para cenários onde várias partes do sistema precisam reagir a eventos ou mudanças de estado de forma sincronizada.

O padrão separa o objeto que gera o evento (o "sujeito") dos objetos que reagem ao evento (os "observadores"), promovendo baixo acoplamento entre eles.

### Objetivo

O principal objetivo do Observer Pattern é permitir que múltiplos objetos sejam informados sobre mudanças em um determinado objeto, mantendo o código modular e flexível. Dessa forma, o sujeito não precisa saber quantos ou quais observadores estão registrados para serem notificados, tornando o sistema mais expansível.

### Estrutura

O **Observer Pattern** geralmente possui a seguinte estrutura:

- **Sujeito (Subject)**: Define uma interface para adicionar, remover e notificar observadores. O sujeito mantém uma lista de observadores registrados.
- **Observadores (Observer)**: Define uma interface para atualização, que todos os observadores devem implementar. Essa interface possui um método que é chamado quando o estado do sujeito muda.
- **Observadores Concretos**: Implementações específicas do observador, que reagem de forma personalizada às atualizações do sujeito.
- **Sujeito Concreto**: Implementa o sujeito e notifica os observadores quando seu estado muda.

### Vantagens do Observer Pattern

1. **Desacoplamento entre Sujeito e Observadores**: O Observer Pattern reduz o acoplamento entre o sujeito e os observadores, permitindo que ambos sejam alterados de forma independente.

2. **Flexibilidade para Múltiplos Observadores**: Múltiplos observadores podem ser registrados e notificados dinamicamente, possibilitando a extensão do sistema sem necessidade de alteração no código do sujeito.

3. **Facilidade de Expansão**: Com o Observer Pattern, novos tipos de observadores podem ser adicionados facilmente, promovendo a escalabilidade do sistema.

4. **Reatividade e Sincronia**: Ideal para sistemas onde as partes dependem de eventos ou mudanças de estado, como em interfaces de usuário, notificações e sistemas de eventos.

### Quando Usar?

Use o **Observer Pattern** quando:

- Múltiplos objetos precisam ser notificados sobre mudanças de estado em outro objeto.
- O sistema exige um baixo acoplamento entre o emissor e os receptores de eventos.
- Você precisa de uma estrutura onde observadores possam ser adicionados ou removidos dinamicamente.
- Um objeto deve ser capaz de notificar outros objetos sobre seu estado sem precisar saber quem são esses objetos.

O **Observer Pattern** é ideal para sistemas baseados em eventos, interfaces reativas e situações onde um-para-muitos de notificação é essencial.

[Voltar ao topo](#)

## Padrão Command

### O que é o Command Pattern?

O **Command Pattern** (Padrão de Comando) é um padrão comportamental que transforma uma solicitação em um objeto autônomo, permitindo parametrizar outros objetos com diferentes solicitações, enfileirar ou registrar solicitações e suportar operações reversíveis. Ele encapsula uma solicitação como um objeto, desacoplando o remetente da solicitação do destinatário, e pode ser utilizado para implementar operações que podem ser desfeitas ou repetidas.

O padrão é útil para situações onde você deseja executar comandos de forma flexível e desacoplada, pois separa o que deve ser feito (comando) de quem faz (o objeto que realiza o comando), permitindo armazenar e executar comandos dinamicamente.

### Objetivo

O objetivo principal do Command Pattern é desacoplar o emissor e o executor da ação, encapsulando ações como objetos, para que possam ser enfileiradas, registradas ou revertidas com facilidade. Isso permite a criação de estruturas flexíveis, onde as solicitações de ações podem ser executadas sob diferentes condições e requisitos, sem que o objeto emissor precise saber os detalhes de como a ação é realizada.

### Estrutura

O **Command Pattern** geralmente envolve os seguintes componentes:

- **Comando (Interface)**: Define o método `Execute()` que todas as classes concretas de comando devem implementar.
- **Comandos Concretos**: Implementações específicas da interface de comando, que realizam uma operação ou ação concreta quando o `Execute()` é chamado.
- **Receptor**: A classe que realmente executa a lógica da ação solicitada pelo comando.
- **Invoker (Invocador)**: Um objeto que conhece apenas a interface do comando e invoca o método `Execute()` do comando concreto, sem saber os detalhes de sua implementação.
- **Cliente**: Cria instâncias de comandos concretos e associa comandos ao invocador.

### Vantagens do Command Pattern

1. **Desacoplamento do Emissor e Receptor**: O Command Pattern separa o objeto que invoca a ação daquele que realmente realiza a ação, permitindo maior modularidade e flexibilidade.

2. **Histórico e Desfazer/Refazer Operações**: Comandos podem ser armazenados em uma pilha para permitir que operações sejam desfeitas ou refeitas, como em sistemas de edição ou transações.

3. **Extensibilidade**: Novos comandos podem ser adicionados sem alterar o código existente, facilitando a manutenção e expansão do sistema.

4. **Centralização de Operações**: O invocador pode manter uma lista de comandos a serem executados em sequência, permitindo executar uma série de ações de forma organizada.

### Quando Usar?

Use o **Command Pattern** quando:

- Você precisa parametrizar objetos com operações, como uma fila de operações ou tarefas agendadas.
- Deseja implementar operações reversíveis (desfazer e refazer).
- É necessário enfileirar, registrar ou centralizar comandos em um sistema.
- Deseja desacoplar o código que emite comandos daquele que os executa.

O **Command Pattern** é ideal para sistemas onde comandos podem ser manipulados dinamicamente, armazenados, executados em sequência, ou revertidos, tornando-o uma escolha poderosa para cenários de operações complexas ou repetitivas.

[Voltar ao topo](#)

## Padrão Iterator

### O que é o Iterator Pattern?

O **Iterator Pattern** (Padrão de Iterador) é um padrão comportamental que permite acessar os elementos de uma coleção de maneira sequencial sem expor sua estrutura interna. Ele cria um iterador que encapsula a lógica de navegação, permitindo que o código cliente percorra os elementos de uma coleção sem precisar conhecer os detalhes de como ela é implementada.

Esse padrão é ideal para sistemas que possuem várias coleções complexas e onde o cliente precisa de uma maneira uniforme de percorrer essas coleções.

### Objetivo

O principal objetivo do Iterator Pattern é fornecer um mecanismo para acessar elementos de uma coleção sem expor a estrutura subjacente dessa coleção. Dessa forma, o padrão oferece flexibilidade para o cliente iterar sobre diferentes tipos de coleções de forma padronizada.

### Estrutura

O **Iterator Pattern** segue uma estrutura composta por:

- **Iterador (Iterator)**: Define a interface para navegar pela coleção, com métodos como `HasNext()` e `Next()` para percorrer os elementos.
- **Iterador Concreto (Concrete Iterator)**: Implementa a interface de iterador e mantém o controle da posição atual na coleção.
- **Agregado (Aggregate)**: Define a interface para criar um iterador, geralmente com um método `CreateIterator()`.
- **Agregado Concreto (Concrete Aggregate)**: Implementa a interface do agregado e cria uma instância do iterador concreto.

### Vantagens do Iterator Pattern

1. **Encapsulamento da Lógica de Navegação**: O Iterator Pattern encapsula a lógica de iteração, mantendo o código cliente focado em usar os elementos e não em navegar pela coleção.

2. **Flexibilidade para Várias Coleções**: O mesmo código cliente pode iterar sobre diferentes tipos de coleções, desde que sigam a interface de iteração definida.

3. **Uniformidade**: Proporciona uma interface comum para navegar por diferentes tipos de coleções, tornando o código mais padronizado e fácil de entender.

4. **Desacoplamento**: O cliente não precisa conhecer a estrutura interna da coleção, promovendo o princípio de baixo acoplamento.

### Quando Usar?

Use o **Iterator Pattern** quando:

- Você precisa acessar os elementos de uma coleção sem expor sua estrutura interna.
- O cliente deve poder percorrer diferentes tipos de coleções de forma uniforme.
- Deseja fornecer várias maneiras de iterar sobre a coleção (ex.: iteração normal, iteração reversa).
- É necessário um controle fino sobre a forma como a coleção é percorrida, encapsulando a lógica de navegação.

O **Iterator Pattern** é ideal para sistemas que exigem uma maneira genérica e desacoplada de navegar em diferentes coleções, promovendo flexibilidade e mantendo o encapsulamento.

[Voltar ao topo](#)

## Padrão Chain of Responsibility

### O que é o Chain of Responsibility Pattern?

O **Chain of Responsibility Pattern** (Padrão de Cadeia de Responsabilidade) é um padrão comportamental que permite que um pedido seja processado por uma sequência de manipuladores, onde cada manipulador decide se lida com o pedido ou o passa para o próximo manipulador na cadeia. Isso promove o desacoplamento entre o objeto que faz a solicitação e os objetos que podem processá-la, criando uma corrente de responsabilidade.

Esse padrão é ideal para cenários onde múltiplos manipuladores podem atender a uma solicitação e o tratamento de cada solicitação depende de condições dinâmicas.

### Objetivo

O objetivo principal do Chain of Responsibility Pattern é evitar o acoplamento rígido entre o remetente e o receptor de uma solicitação, permitindo que a solicitação passe por uma cadeia de manipuladores até que um deles a processe ou a cadeia termine. Isso oferece flexibilidade na forma como as solicitações são tratadas, permitindo fácil extensão ou modificação da cadeia.

### Estrutura

O **Chain of Responsibility Pattern** segue uma estrutura composta por:

- **Handler (Manipulador)**: Define a interface para processar as solicitações e possui uma referência ao próximo manipulador da cadeia.
- **Handler Concreto**: Implementa o método de tratamento e decide se processa a solicitação ou a passa adiante na cadeia.
- **Cliente**: Cria a cadeia de manipuladores e passa as solicitações para o primeiro manipulador.

### Vantagens do Chain of Responsibility Pattern

1. **Desacoplamento do Emissor e do Receptor**: O padrão desacopla o objeto que faz a solicitação dos objetos que podem tratá-la, promovendo flexibilidade e extensibilidade.

2. **Flexibilidade na Cadeia**: A cadeia de manipuladores pode ser alterada dinamicamente, e novos manipuladores podem ser adicionados ou removidos sem impactar o código existente.

3. **Distribuição de Responsabilidades**: Responsabilidades são divididas entre os manipuladores, permitindo que cada um seja especializado em uma parte específica do processo.

4. **Aumento da Reutilização**: Manipuladores podem ser reutilizados em diferentes cadeias, aumentando a modularidade do sistema.

### Quando Usar?

Use o **Chain of Responsibility Pattern** quando:

- Mais de um objeto pode lidar com uma solicitação, e o objeto que a processará deve ser determinado em tempo de execução.
- Você quer enviar uma solicitação para um grupo de objetos sem especificar explicitamente o receptor.
- Deseja implementar um sistema onde uma solicitação passe por uma cadeia de manipuladores e cada um tenha a oportunidade de tratá-la.

O **Chain of Responsibility Pattern** é ideal para sistemas que necessitam de processamento em cadeia, onde a responsabilidade por uma solicitação é distribuída por vários objetos, promovendo flexibilidade e baixa dependência entre componentes.

[Voltar ao topo](#)

## Padrão Interpreter

### O que é o Interpreter Pattern?

O **Interpreter Pattern** (Padrão de Interpretador) é um padrão comportamental que define uma representação para a gramática de uma linguagem e um interpretador que usa essa gramática para interpretar sentenças na linguagem. Ele é usado para avaliar ou processar linguagens simples e expressões, e cada tipo de expressão é representado por uma classe concreta.

Esse padrão é ideal para cenários onde o sistema precisa interpretar ou avaliar expressões recorrentes de uma linguagem definida, como cálculos matemáticos ou regras lógicas.

### Objetivo

O objetivo principal do Interpreter Pattern é definir uma estrutura para representar e avaliar linguagens ou expressões específicas de um domínio. Com esse padrão, é possível criar classes específicas para cada elemento da linguagem, tornando o código mais modular e de fácil manutenção.

### Estrutura

O **Interpreter Pattern** geralmente possui a seguinte estrutura:

- **Expressão (Expression)**: Define a interface para a interpretação das expressões. Cada tipo de expressão deve implementar essa interface.
- **Expressão Concreta (Concrete Expression)**: Implementa a interpretação de expressões específicas, como operadores matemáticos ou literais.
- **Contexto (Context)**: Armazena informações globais relevantes para a interpretação. Pode conter variáveis e valores que as expressões utilizam.
- **Cliente**: Constrói e executa a árvore de interpretação com base na linguagem definida.

### Vantagens do Interpreter Pattern

1. **Modularidade e Extensibilidade**: Cada expressão concreta representa um componente da linguagem, tornando o sistema modular e fácil de expandir com novos elementos de linguagem.

2. **Facilidade de Adaptação**: A estrutura de classes pode ser facilmente adaptada para suportar mudanças na linguagem ou adicionar novas operações.

3. **Reutilização**: Classes de expressão concreta podem ser reutilizadas em diferentes partes da aplicação, promovendo consistência na interpretação.

4. **Simplicidade para Linguagens Pequenas**: Ideal para interpretar ou avaliar linguagens pequenas ou específicas de domínio.

### Quando Usar?

Use o **Interpreter Pattern** quando:

- Você possui uma linguagem ou expressão bem definida que precisa ser interpretada de forma recorrente.
- A estrutura da linguagem é simples e pode ser representada através de classes concretas.
- É necessário modificar ou expandir a linguagem de forma independente, sem impactar o restante do sistema.

O **Interpreter Pattern** é ideal para linguagens específicas de domínio ou para avaliação de expressões recorrentes, como cálculos matemáticos ou regras lógicas, oferecendo flexibilidade e modularidade.

[Voltar ao topo](#)

