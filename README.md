# ExempleLluis
***
## Descripció
Programa exemple d'ús de Task amb WaitAll i WhenAll, async/await i threads per gestionar una aplicació gràfica WinForms. Cadascun dels botons genera 10 instàncies de la classe caixera. Aquesta classe té una propietat i dos mètodes que que simulen una tasca que se simula fent un retard de 5 segons, en un cas de forma síncrona, mitjanaçant *Thread.Sleep* i l'altre de forma asíncrona amb *await Task.Delay*.

S'oberva com les opcions asíncrones no bloquen la interfície mentre que les síncrones sí.
