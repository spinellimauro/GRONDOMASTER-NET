import { Component, OnInit } from '@angular/core';
import { Jugador } from 'src/app/models/Jugador';
import { ConfigService } from 'src/app/utils/config.service';
import { UtilService } from 'src/app/utils/util.service';
import { JugadorService } from '../../mercado/jugadorService';
import { PlantillaService } from '../plantillaService';

@Component({
  selector: 'equipos-root',
  templateUrl: './equipos.component.html',
  styleUrls: ['./equipos.component.scss'],
})
export class EquipoComponent implements OnInit {
  jugadores: Jugador[] = [];
  cols: any[] = [];

  constructor(
    private plantillaService: PlantillaService,
    private configService: ConfigService,
    private utilService: UtilService
  ) {}

  ngOnInit() {
    this.cols = [
      { field: 'nombre', header: 'Nombre' },
      { field: 'nacionalidadCorta', header: 'Nacionalidad' },
      { field: 'edad', header: 'Edad' },
      { field: 'posiciones', header: 'Posiciones' },
      { field: 'nivel', header: 'Nivel' },
      { field: 'potencial', header: 'Potencial' }
    ];

    this.plantillaService
      .getPlantilla()
      .subscribe((jugadores: Jugador[]) => {
        jugadores.forEach(jugador => {
          var nacionalidadLowerCase = jugador.nacionalidad.toLowerCase();
          jugador.nacionalidad = nacionalidadLowerCase;
          this.jugadores = jugadores;
        });
       
      });
  }

  changeSource($event) {
    $event.target.src = '../../../../assets/images/notfound_0_120.png';
  }

}
