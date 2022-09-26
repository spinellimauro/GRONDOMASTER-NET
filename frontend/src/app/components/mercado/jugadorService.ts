import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from '../../utils/config.service';
import { Jugador } from 'src/app/models/Jugador';

@Injectable()
export class JugadorService {
  constructor(private http: HttpClient, private configService: ConfigService) {}

  getJugadoresBySearch(query: string) {
    return this.http.get(
      this.configService.JugadorURI + 'get-jugadores-by-search?query=' + query
    );
  }

  comprarJugador(model : Jugador) {
    return this.http.post(
      this.configService.PlantillaURI + 'comprar-jugador', model
    );
  }
}
