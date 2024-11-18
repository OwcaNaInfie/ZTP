# Zadanie Programistyczne – Wzorzec Projektowy Composite

## **Krok 1 – Grupa zadań**

1. **Stwórz wspólny interfejs klas `TaskGroup` oraz `Task`** (np. `ITaskComponent`).
2. **Struktura grupy zadań:**
   - Grupa przechowuje listę komponentów (`List<ITaskComponent>`), które mogą być zadaniami lub innymi grupami zadań.
   - Hierarchiczna struktura umożliwia dowolne zagnieżdżanie grup i zadań.
3. **Zasady działania:**
   - **Data rozpoczęcia grupy** odpowiada najwcześniejszej dacie rozpoczęcia wśród jej komponentów.
   - **Data zakończenia grupy** odpowiada najpóźniejszej dacie zakończenia wśród jej komponentów.
   - **Grupa jest uznawana za ukończoną**, jeśli wszystkie jej komponenty są wykonane (`IsCompleted` wykorzystuje `All`).
4. **Oznaczenie grupy jako wykonanej (`MarkAsCompleted`)**:
   - Oznacza wszystkie komponenty grupy jako wykonane (rekurencyjnie).
   - Zadania już ukończone nie są oznaczane ponownie.
5. **Wyświetlanie hierarchicznej struktury zadań:**
   - Użyj wcięć lub innego formatowania dla podzadań.
6. **Zliczanie zadań:**
   - Zaimplementuj możliwość podsumowania zadań wykonanych/niewykonanych z dotrzymaniem lub przekroczeniem terminów.

---

## **Krok 2 – Grupa zadań opcjonalnych** (*)

1. **Dodaj nowy typ grupy `OptionalTaskGroup`:**
   - Przeznaczona do grup, z których należy zrealizować przynajmniej jedno zadanie.
2. **Zasady działania:**
   - **Grupa jest uznawana za zrealizowaną**, jeśli przynajmniej jedno z jej zadań zostało wykonane.
   - Próba oznaczenia grupy jako wykonanej powoduje oznaczenie losowego podzadania (jeśli żadne nie zostało jeszcze wykonane).
3. **Sprawdzanie poprawności:**
   - Upewnij się, że oba rodzaje grup (`TaskGroup` i `OptionalTaskGroup`) działają zgodnie z założeniami.

---

## **Krok 3 – Logika rysowania wykresu Gantta** (**)

1. **Cel wykresu Gantta:**
   - Wizualne przedstawienie harmonogramu projektu.
   - Oś `x` oznacza czas, a każdy wiersz reprezentuje jedno zadanie:
     - `X` – zadanie ukończone na czas.
     - `!` – zadanie ukończone z opóźnieniem.
     - `#` – zadanie w toku.
     - `.` – brak aktywności.
2. **Metoda `GenerateGanttChart`:**
   - **Parametry:**
     - `DateTime projectStart`: początek wykresu.
     - `DateTime projectEnd`: koniec wykresu.
   - Dla każdego zadania generuj pasek czasu zgodnie z jego stanem.
3. **Przykład wykresu Gantta:**

   ```plaintext
   Zadanie 1   ..XX........
   Zadanie 2   ....!!!!!!..
   Zadanie 3   .......#####.
   ```

4. **Generowanie wykresu dla całego projektu:**
   - Wywołanie:  
     ```csharp
     Console.WriteLine(project.GenerateGanttChart(project.StartDate, project.EndDate));
     ```

---

## **Krok 4 – Zadania cykliczne** (***)

1. **Dodaj nowy typ zadania `RecurringTask`:**
   - Reprezentuje zadania powtarzające się cyklicznie w określonych odstępach czasu.
2. **Parametry zadania:**
   - `DateTime StartDate`: początek cyklu.
   - `DateTime EndDate`: koniec cyklu.
   - `int IntervalInDays`: odstęp czasowy między kolejnymi wystąpieniami.
3. **Obsługa cykliczności:**
   - Każde wystąpienie zadania ma własny status:
     - **Na czas** – ukończone przed terminem.
     - **Z opóźnieniem** – ukończone po terminie.
     - **Niewykonane** – brak oznaczenia ukończenia.
   - Oznaczenie zadania cyklicznego jako wykonane dotyczy wyłącznie wystąpień poprzedzających podaną datę.
4. **Wyświetlanie na wykresie Gantta:**
   - Zamiast bloku, użyj pojedynczych znaków z odstępami odpowiadającymi interwałowi:
     - `..X..X..!..#..#....`

---

## **Podsumowanie**

Implementacja powinna obejmować:

1. **Interfejs `ITaskComponent`** dla spójności.
2. **Klasy:**
   - `Task`
   - `TaskGroup`
   - `OptionalTaskGroup`
   - `RecurringTask`
3. **Funkcjonalności:**
   - Wyświetlanie struktury hierarchicznej zadań.
   - Generowanie podsumowań zadań.
   - Rysowanie wykresu Gantta.
   - Obsługa zadań cyklicznych.