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

- **[Padrão Strategy](#padrão-strategy)**: Define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. 
- **Observer**: Define uma dependência um-para-muitos entre objetos, onde quando um objeto muda, seus dependentes são notificados.
- **Command**: Encapsula uma solicitação como um objeto, permitindo parametrizar filas de execução e logs.
- **Iterator**: Fornece uma maneira de acessar sequencialmente os elementos de uma coleção sem expor sua implementação subjacente.
- **Mediator**: Define um objeto intermediário que encapsula como um conjunto de objetos interage.
- **Memento**: Captura e restaura o estado interno de um objeto sem violar seu encapsulamento.
- **State**: Permite que um objeto altere seu comportamento quando seu estado interno muda.
- **Template Method**: Define o esqueleto de um algoritmo, delegando alguns passos para subclasses.
- **Visitor**: Permite adicionar novas operações a uma estrutura de objetos sem modificar as classes que a compõem.
- **Chain of Responsibility**: Passa uma solicitação por uma cadeia de manipuladores até que ela seja processada.
- **Interpreter**: Avalia e executa uma linguagem ou expressão com base em uma gramática definida.

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
   - ObserverPattern.cs (Padrão Observer)
   - CommandPattern.cs (Padrão Command)
   - IteratorPattern.cs (Padrão Iterator)
   - MediatorPattern.cs (Padrão Mediator)
   - MementoPattern.cs (Padrão Memento)
   - StatePattern.cs (Padrão State)
   - TemplateMethodPattern.cs (Padrão Template Method)
   - VisitorPattern.cs (Padrão Visitor)
   - ChainOfResponsibilityPattern.cs (Padrão Chain of Responsibility)
   - InterpreterPattern.cs (Padrão Interpreter)

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
