# AmongUsUnknownImpostors
ATTENTION ⚠️ | ANNONCE !
Ce mod sera disponnible en 2025 et sera joué en LIVE avec les Royales pour le retour.

Among Us mod qui corrige quelques bugs qui perturbent le jeu lors des tryhardings parmi nous. Ainsi que quelques paramètres utiles

## Caractères

-  Les imposteurs ne se connaissent pas
-  Les imposteurs peuvent s'entre-tuer
-  Les imposteurs sont touchés par le sabotage des lumières (cela peut être personnalisé individuellement dans les paramètres du lobby)
-  Le module peut être désactivé à partir d'une commande du lobby et sera automatiquement désactivé si l'hôte n'a pas installé le mod.
- Vous permet de modifier la carte et le nombre d'imposteurs depuis le lobby du jeu.

## Technique

Ce mod a été réalisé à l'aide du [framework de modding Reactor](https://github.com/NuclearPowered/Reactor), basé sur BepInEx, il corrige le jeu au moment de l'exécution et **NE** modifie aucun fichier de jeu.
-   Support Among us v 2024.3.5s (Steam only)

### Installation

Tous les joueurs doivent avoir installé le mod pour la meilleure expérience utilisateur

-   Download the [lastest release](https://github.com/AnthoYt/AmongUsUnknownImpostors/releases).
-   Extract the files into Among us game folder (`steam/steamapps/common/Among us`)
-   This should look like this
    ![looklikethis](./Visuals/looklikethis.png)
-   **Run the game from steam**

### Installation side note

If you want to install Reactor by yourself, please follow the [BepInEx](https://docs.reactor.gg/docs/basic/install_bepinex) installation instruction, then [Reactor](https://docs.reactor.gg/docs/basic/install_reactor)'s ones. And then copy the plugin dll (from [releases](https://github.com/Herysia/AmongUsTryhard/releases/latest)) into `Among us/BepInEx/plugins`
If you want to play on official servers, you should then disable custom handshake option from: `Among us/BepInEx/config/gg.reactor.api.cfg`

### Uninstall

If you want to uninstall this mod only, remove the dll `Among us/BepInEx/plugins/AmongUsUnknownImpostors-2020.12.9s.dll`.

If you want to disable it, you can temporarily rename or remove the file `Among us/winhttp.dll` ou désintalle le jeu pour le reinstaller dans le mod.

If you want to completely uninstall Reactor/BepInEx, remove the following files and folders

```
+-- BepInEx
+-- mono
+-- changelog.txt
+-- doorstop_config.ini
+-- winhttp.dll
```

# Contribution

Vous avez rencontré un bug ou un comportement inattendu ? Vous souhaitez proposer ou ajouter une nouvelle fonctionnalité ? Créez un [Problème](https://github.com/Herysia/AmongUsUnknownImpostors/issues) ou un [PR](https://github.com/Herysia/AmongUsUnknownImpostors/pulls) !

### Dependency

This mod depends on [another module](https://github.com/Herysia/CustomLobbyOptions) which simplify lobby options (add to menu, sync settings and save settings individually with customisable display)

### Creating PR

-   [Fork this on github](https://github.com/Herysia/AmongUsUnknownImpostors/fork)
-   Clone your repo, commit and push your changes
-   Request a new Pull request

# Licensing & Credits

AmongUsUnknownImpostors is licensed under the MIT License. See [LICENSE](LICENSE.md) for the full License.

Credits to [@Galster](https://github.com/Galster-dev) for custom lobby settings

Third-party libraries:

-   [Reactor](https://github.com/NuclearPowered/Reactor) is license under the LGPL v3.0 License. See [LICENSE](https://github.com/NuclearPowered/Reactor/blob/master/LICENSE) for the full License.
-   [BepInEx (Reactor fork)](https://github.com/NuclearPowered/BepInEx) is licensed under the LGPL 2.1 License. See [LICENSE](https://github.com/NuclearPowered/BepInEx/blob/master/LICENSE) for the full License.
-   Unity Runtime libraries are part of Unity Software.  
    Their usage is subject to [Unity Terms of Service](https://unity3d.com/legal/terms-of-service), including [Unity Software Additional Terms](https://unity3d.com/legal/terms-of-service/software).

# Contact
Discord :
antho_off

Youtube :
Antho_Off
