
# IAV - Fantasmicos al poder

# IAV - Documento de Producción del Proyecto Final

<br>

> [!CAUTION]
> La licencia sobre la herramienta ........ incluída en este repositorio no es de uso libre. Se recomienda no usar sin disponer de una licencia válida. Se encuentra aquí disponible debido a que no se ha podido retirar para el correcto funcionamiento de la versión final del proyecto. No me hago cargo de las responsabilidades legales que puedan recaer sobre quien haga uso de estas herramientas sin autorización previa del propietario original. El uso de esta herramienta en este repositorio tiene únicamente la finalidad de aportar académicamente a un trabajo universitario sin ánimo de lucro ni difusión.

<br>

## Autor
- Muxu Rubia Luque ([RubiaLuque](https://github.com/RubiaLuque))
<br>

## Propuesta

Este se trata del proyecto final de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos en la UCM. 

Este proyecto consiste en la creación de un prototipo de IA que se basa en el movimiento en grupo y persecución al jugador. El juego se desarrolla en un mundo en 3D y tiene un sistema basado en juegos roguelike de acción. Consta de dos mapas con puntos de spawn en los que se suceden oleadas de enemigos que el protagonista debe abatir antes de poder pasar de mapa o nivel y así salir de la mazmorra en la que está encerrado. La IA irá guiando a cada grupo de enemigos, formado de 3 a 5 fanasmas, hacia el jugador para atacarle. Estos fantasmas están encabezados por un líder que determina la marcha. El objetivo es mantener la formación durante el trayecto mientras se esquivan obstáculos o se pasan por pasillos estrechos. Se requiere de adaptabilidad y flexibilidad para acercarse al jugador, desaciendo las posiciones cuando se requiera y volviendo a recomponerse después. Habrá diferentes tipos de formaciones grupales de enemigos.

<br>

## Punto de partida
Se parte de un proyecto base de **Unity 2022.3.5f1** 

<br><br>
## Guía de estilo del código
Para dar cohesión al trabajo, se ha acordado el uso de unas directrices que seguir a la hora de programar el código (que no el pseudocódigo). Estas son:
- El uso de Camel Case para las variables, ya sean privadas o públicas. Un ejemplo de esto sería: ```int varName```.
- El uso de Pascal Case para la declaración y uso de clases. Por ejemplo: ```class MyClass```. Además de para las funciones, ya que sigue el protocolo de C# para Unity. Por ejemplo: ```void MyFunction()```.
  
Todo el código se escribirá en inglés a excepción de los comentarios, que serán en español. En algunas excepciones se ha usado inglés, siguiendo con la estructura y forma del código base. Lo ideal es que todas las funciones vayan acompañadas de un comentario que describa brevemente su código a no ser que su nombre o brevedad sean autoexplicativos.

<br><br>
## Diseño de la solución


## Pruebas y métricas


Característica A: Movimiento del personaje y cámara
<table>
    <tr>
        <th><b>A.1</b></th>
        <th>Probar el movimiento correcto con WASD del protagonista.</th>
    </tr>
     <tr>
        <th><b>A.2</b></th>
        <th>Seguimiento correcto de la cámara al jugador.</th>
    </tr>
    
</table>
<br>
Característica B: Creación de los dos niveles
<table>
    <tr>
        <th><b>B.1</b></th>
        <th>Comprobar que los puntos de spawn funcionan correctamente. </th>
    </tr>
    <tr>
        <th><b>B.2</b></th>
        <th>...</th>
    </tr>
    
</table>
<br>
Característica C: Ciclo de juego
<table>
    <tr>
        <th><b>C.1</b></th>
        <th>Comrpobar que se pasa correctamente del nivel 1 al 2 al derrotar a todos los enemigos del 1.</th>
    </tr>
    <tr>
        <th><b>C.2</b></th>
        <th>Comprobar que se acaba el juego y se vuelve al menú cuando se acaba con todos los enemigos del nivel 2.</th>
    </tr>
</table>
<br>
Característica D: Persecución con A*
<table>
    <tr>
        <th><b>D.1</b></th>
        <th>Comprobar que el lider de la formación puede trazar un camino óptimo hacia el jugador esquivando obstáculos.</th>
    </tr>
</table>
<br>
Característica E: Movmiento el grupo
<table>
    <tr>
        <th><b>E.1</b></th>
        <th>Probar que la formación puede adaptarse a pasillos estrechos del nivel 2.</th>
    </tr>
  <tr>
        <th><b>E.2</b></th>
        <th>Probar que la formación puede rodear los obtáculos del nivel 1.</th>
    </tr>
  <tr>
        <th><b>E.3</b></th>
        <th>Probar que hay una formación que avanza en línea horizontal.</th>
    </tr>
</table>
<br>

<br>



## Producción


| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
| :x: | Diseño: Documentación inicial | 16-05-2024 |
| :x: | Característica A: Movimiento del personaje y cámara | 28-05-2024 |
| :x: | Característica B: Creación de los dos niveles | 28-05-2024 |
| :x: | Característica C: Ciclo de juego | 28-05-2024 |
| :x: | Característica D: Persecución con A* | 28-05-2024 |
| :x: | Característica E: Movimiento en grupo | 28-05-2024 |
| :x: | Diseño: Documentación final | 28-05-2024 |
| :x: | Vídeo | 28-05-2024 |




<br><br>

## Referencias

Los recursos de terceros utilizados son de uso público.

- *AI for Games*, Ian Millington.

