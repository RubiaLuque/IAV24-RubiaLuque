
# IAV - Fantasmicos al poder

# IAV - Documento de Producción del Proyecto Final

<br>

## Autor
- Muxu Rubia Luque ([RubiaLuque](https://github.com/RubiaLuque))
<br>

## Propuesta



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


Característica A: Mundo virtual
<table>
    <tr>
        <th><b>A.1</b></th>
        <th>Probar en el nivel 1 el movimiento de robot.</th>
    </tr>
     <tr>
        <th><b>A.2</b></th>
        <th>Probar que funciona el zoom en todos los niveles.</th>
    </tr>
    
</table>
<br>
Característica B: Puertas y escondites
<table>
    <tr>
        <th><b>B.1</b></th>
        <th>Las puertas, cuando están cerradas, bloquean tanto la visibilidad de los guardias como el movimiento de todos los robots. </th>
    </tr>
    <tr>
        <th><b>B.2</b></th>
        <th>Los escondites bloquean la visibilidad de los guardias.</th>
    </tr>
    <tr>
        <th><b>B.3</b></th>
        <th>Las paredes bloquean la visibilidad de los guardias.</th>
    </tr>
    
</table>
<br>
Característica C: Guardias
<table>
    <tr>
        <th><b>C.1</b></th>
        <th>Cuando están en idle, los guardias permanecen en un estado de patrulla empezando y acabando en su base. Comprobar en dos guardias distintos sus puntos de patrulla.</th>
    </tr>
    <tr>
        <th><b>C.2</b></th>
        <th>Si detectan al jugador con su campo de visión, los guardias empiezan a perseguirlo y dispararle.</th>
    </tr>
    <tr>
        <th><b>C.3</b></th>
        <th>Al matar al jugador o perderlo de vista, los guardias vuelven a patrullar.</th>
    </tr>
     <tr>
        <th><b>C.4</b></th>
        <th>Comprobar que al quedarse sin munición, los guardias vuelven a su base a recargar.</th>
    </tr>
</table>
<br>
Característica D: Árbol de comportamientos
<table>
    <tr>
        <th><b>D.1</b></th>
        <th>Probar si la IA es capaz de sacar a Néstor del escenario de ejemplo con vida.</th>
    </tr>
   <tr>
        <th><b>D.2</b></th>
        <th>Néstor cambia su rumbo y recarga vida cuando le queda menos de 1/3.</th>
    </tr>
</table>
<br>
Característica E: Memoria
<table>
    <tr>
        <th><b>E.1</b></th>
        <th>Teniendo memoria, la IA puede sacar a Néstor con vida del nivel 1.</th>
    </tr>
  <tr>
        <th><b>E.2</b></th>
        <th>Teniendo memoria, la IA puede sacar a Néstor con vida del nivel 2.</th>
    </tr>
  <tr>
        <th><b>E.3</b></th>
        <th>Teniendo memoria, la IA puede sacar a Néstor con vida del nivel 3 (nivel prueba).</th>
    </tr>
</table>
<br>

- [Vídeo con la batería de pruebas](https://youtu.be/Gc9cRzQK4xI)

Por si acaso no va el vídeo en youtube porque lleva una hora procesándose: 
[Enlace a drive](https://drive.google.com/file/d/1g9pz_VC4k-2DsYKUajGFlNIrj6LF4NeT/view?usp=sharing)

<br><br><br>



## Producción

Las tareas se han realizado y el esfuerzo ha sido repartido entre los autores. Esto queda documentado en la tabla siguiente de manera general, aunque se encuentra más profundamente documentado en la [pestaña de Proyectos actualizada](https://github.com/orgs/IAV24-G10/projects/3) de GitHub.

| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
| ✔ | Diseño: Documentación inicial | 18-04-2024 |
| ✔ | Característica A: Mundo virtual | 28-04-2024 |
| ✔ | Característica B: Puertas | 28-04-2024 |
| ✔ | Característica C: Guardias | 28-04-2024 |
| ✔ | Característica D: Protagonista | 28-04-2024 |
| ✔ | Característica E: Pizarra | 28-04-2024 |
| ✔ | Diseño: Documentación final | 28-04-2024 |
| :x: | Vídeo | 28-04-2024 |
|   |  | |
|  | OPCIONAL |  |
| :x: | Movimiento e interacción con ratón y WASD. Cambio con barra espaciadora | - |
| :x: | Máquina de estados jerárquica para los guardias | - |
| :x: | Escenario con geometría compleja 3D. Varios niveles. | - |
| :x: | Mecanismos más complejos de escenario (puertas giratorias, ascensores...) | - |
| :x: | Mejora de gestión sensorial del protagonista con retroalimentación visual | - |


<br><br>

## Referencias

Los recursos de terceros utilizados son de uso público.

- *AI for Games*, Ian Millington.
- [Behaviour Bricks Documentation](https://bb.padaonegames.com/)
- [Kaykit Medieval Builder Pack](https://kaylousberg.itch.io/kaykit-medieval-builder-pack)
- [Federico Peinado, Robot a la Fuga, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/robot-a-la-fuga/)
- [Federico Peinado, Representación del conocimiento, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/representacion-del-conocimiento/)
- [Fededrico Peinado, Máquina de estados, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/maquina-de-estados/)
- [Federico Peinado, Árbol de comportamiento, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/arbol-de-comportamiento/)
- [Federico Peinado, Reglas y planificación, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/reglas-y-planificacion/)
- [Federico Peinado, Probabilidad y utilidad, Narratech](https://narratech.com/es/inteligencia-artificial-para-videojuegos/decision/probabilidad-y-utilidad/)
