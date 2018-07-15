import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) { }

  public games = [];

  loadGames() {
    return this.http.get("/api/games")
      .map((data: any) => {
        this.games = data.games;
        return true;
      });
  }

}
