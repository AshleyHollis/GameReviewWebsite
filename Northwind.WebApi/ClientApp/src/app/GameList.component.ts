import { Component, OnInit } from "@angular/core";
import { DataService } from "./shared/dataService";

@Component({
  selector: "game-list",
  templateUrl: "gameList.component.html",
  styleUrls: []
})

export class GameList implements OnInit {

  constructor(private data: DataService) {
  }

  games = [];

  ngOnInit(): void {
    this.loadGames();
  };
  

  loadGames() {
    this.data.loadGames()
      .subscribe(success => {
          if (success) {
            this.games = this.data.games;
          }},
        (error: any) => console.log(error),
        () => console.log('loadGames() retrieved games'));
  }
}
