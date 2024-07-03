using static System.Console;


Write("Введите, через запятую, количество фишек у всех игроков: ");
string[] strs = ReadLine().Split(',');
int elemenCount = strs.Length;
int numMoves = 0; // Количество ходов
int[] chips = new int[elemenCount]; // фишки
int allChip = 0; // сколько всего фишек
for (int i = 0; i < elemenCount; i++)
{
    chips[i] = Convert.ToInt32(strs[i]);
    allChip += chips[i];
}
if (allChip % elemenCount != 0) // если фишки не деляться ровно
{
    Console.WriteLine("Фишки не делятся ровно между игроками");
    return;
}
int idxMin = 0, idxMax = 0; // поиск индексов игроков с максимальным и минимальным количеством фишек
for (int i = 0; i < elemenCount; i++)
{
    if (chips[idxMax] < chips[i]) idxMax = i;
    if (chips[idxMin] > chips[i]) idxMin = i;
}
while (idxMax > idxMin) // пока максимальное и минимальное количество не будут равны
{
    //если справа/ слева индекс больше от минимального, то передвигаем фишку из макисмального индекса соответственно в нужную сторону направо / налево
    if (idxMin < idxMax)
    {
        if (idxMax - idxMin > elemenCount / 2)
        {
            chips[idxMax]--;
            if (idxMax < elemenCount - 1) idxMax++;
            else idxMax = 0;
            chips[idxMax]++;
        }
        else
        {
            chips[idxMax]--;
            if (idxMax > 0) idxMax--;
            else idxMax = elemenCount - 1;
            chips[idxMax]++;
        }
    }
    else
    {
        if (idxMin - idxMax < elemenCount / 2)
        {
            chips[idxMax]--;
            if (idxMax < elemenCount - 1) idxMax++;
            else idxMax = 0;
            chips[idxMax]++;
        }
        else
        {
            chips[idxMax]--;
            if (idxMax > 0) idxMax--;
            else idxMax = elemenCount - 1;
            chips[idxMax]++;
        }
    }
    numMoves++;
    idxMin = 0;
    idxMax = 0;
    for (int i = 0; i < elemenCount; i++) // поиск максимальной/минимальной кучки фишек
    {
        if (chips[idxMax] < chips[i]) idxMax = i;
        if (chips[idxMin] > chips[i]) idxMin = i;
    }
}
WriteLine($"Фишки были распределены за {numMoves} ходов");
ReadLine();


