# Размещение компонентов на печатной плате

## Цели работы <br>
<p align="justify"> Работа посвящена разработке подсистемы, предназначенной для автоматизации процесса размещения компонентов на печатной плате. В рамках данного проекта был проведен анализ процесса проектирования печатных плат, разработан алгоритм для решения задачи размещения компонентов, создано информационное обеспечение, а также разработана программа для автоматизированного проектирования печатных плат. </p>

## Метод решения <br>
<p align="justify"> В данной работе для решения задачи размещения компонентов на печатной плате был применен нейросетевой подход. Этот метод позволяет системе обучаться в процессе проектирования, в отличие от многих существующих алгоритмов, таких как генетический алгоритм и имитационный отжиг. Отсутствие обучения в этих алгоритмах означает их неспособность к адаптации и улучшению на каждой итерации решения задачи проектирования. 
Нейросеть была построена на базе архитектуры самоорганизующихся карт Кохонена. Такой выбор был сделан в силу способности данной нейронной сети группировать компоненты согласно заданным критериям и эффективно располагать их на печатной плате. Сети Кохонена, по существу, сохраняют топологическое положение данных, что помогает уменьшить длину связей между компонентами на плате и в целом повысить производительность. </p>
