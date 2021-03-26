import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';

import { ResistorService } from 'src/app/Resistors/services/resistor.service';
import { BandDetail } from 'src/app/Resistors/models/band-detail';
import { OhmResistance } from 'src/app/Resistors/models/ohm-resistance';

@Component({
  selector: 'app-resistor-data',
  templateUrl: './resistor-data.component.html',
  styleUrls: ['./resistor-data.component.css']
})
export class ResistorDataComponent implements OnInit {

  public bracketInput: string;
  public matchingBracket: boolean;

  public bandsA: BandDetail[];
  public bandsB: BandDetail[];
  public bandsC: BandDetail[];
  public bandsD: BandDetail[];

  public selectedBandA: any;
  public selectedBandB: any;
  public selectedBandC: any;
  public selectedBandD: any;

  public ohmResistance: OhmResistance;

  constructor(protected resistorService: ResistorService) {
  }

  ngOnInit() {
    this.selectedBandA = 'black';
    this.selectedBandB = 'black';
    this.selectedBandC = 'pink';
    this.selectedBandD = 'white';

    this.bandsA = [
      { backgroundColor: 'black', color: 'white', value: 'black' },
      { backgroundColor: 'brown', color: 'white', value: 'brown' },
      { backgroundColor: 'red', color: 'white', value: 'red' },
      { backgroundColor: 'orange', color: 'white', value: 'orange' },
      { backgroundColor: 'yellow', color: 'black', value: 'yellow' },
      { backgroundColor: 'green', color: 'white', value: 'green' },
      { backgroundColor: 'blue', color: 'white', value: 'blue' },
      { backgroundColor: 'violet', color: 'white', value: 'violet' },
      { backgroundColor: 'grey', color: 'white', value: 'grey' },
      { backgroundColor: 'white', color: 'black', value: 'white' }
    ];

    this.bandsB = [
      { backgroundColor: 'black', color: 'white', value: 'black' },
      { backgroundColor: 'brown', color: 'white', value: 'brown' },
      { backgroundColor: 'red', color: 'white', value: 'red' },
      { backgroundColor: 'orange', color: 'white', value: 'orange' },
      { backgroundColor: 'yellow', color: 'black', value: 'yellow' },
      { backgroundColor: 'green', color: 'white', value: 'green' },
      { backgroundColor: 'blue', color: 'white', value: 'blue' },
      { backgroundColor: 'violet', color: 'white', value: 'violet' },
      { backgroundColor: 'grey', color: 'white', value: 'grey' },
      { backgroundColor: 'white', color: 'black', value: 'white' }
    ];

    this.bandsC = [
      { backgroundColor: 'pink', color: 'white', value: 'x0.001' },
      { backgroundColor: 'silver', color: 'white', value: 'x0.01' },
      { backgroundColor: 'gold', color: 'white', value: 'x0.1' },
      { backgroundColor: 'black', color: 'white', value: 'x1' },
      { backgroundColor: 'brown', color: 'white', value: 'x10' },
      { backgroundColor: 'red', color: 'white', value: 'x100' },
      { backgroundColor: 'orange', color: 'white', value: 'x1000' },
      { backgroundColor: 'yellow', color: 'black', value: 'x10 000' },
      { backgroundColor: 'green', color: 'white', value: 'x100 000' },
      { backgroundColor: 'blue', color: 'white', value: 'x1 000 000' },
      { backgroundColor: 'violet', color: 'white', value: 'x10 000 000' },
      { backgroundColor: 'grey', color: 'white', value: 'x100 000 000' },
      { backgroundColor: 'white', color: 'black', value: 'x1 000 000 000' }
    ];

    this.bandsD = [
      { backgroundColor: 'white', color: 'black', value: '± 20%' },
      { backgroundColor: 'silver', color: 'white', value: '± 10%' },
      { backgroundColor: 'gold', color: 'white', value: '± 5%' },
      { backgroundColor: 'brown', color: 'white', value: '± 1%' },
      { backgroundColor: 'red', color: 'white', value: '± 2%' },
      { backgroundColor: 'orange', color: 'white', value: '± 0.05%' },
      { backgroundColor: 'yellow', color: 'black', value: '± 0.02%' },
      { backgroundColor: 'green', color: 'white', value: '± 0.5%' },
      { backgroundColor: 'blue', color: 'white', value: '± 0.25%' },
      { backgroundColor: 'violet', color: 'white', value: '± 0.1%' },
      { backgroundColor: 'grey', color: 'white', value: '± 0.01%' },
      
    ];
  }

  public submit(): void {
    this.resistorService.calculateOhmValue(this.selectedBandA, this.selectedBandB, this.selectedBandC, this.selectedBandD).pipe(take(1)).subscribe(result => {
      this.ohmResistance = result;
    }, error => console.error(error));
  }

  public areBracketsClosed(bracket: string): boolean {
    bracket = bracket.trim();
    if (bracket.length <= 1) {
      this.matchingBracket = false;
      return false;
    }

    const openingBrackets = ['[', '(', '{'];
    const closingBrackets = [']', ')', '}'];

    let bracketArray = [];
    let matchOpeningBracket, item;
    
    for (let i = 0; i < bracket.length; i++) {
      item = bracket[i]

      if (closingBrackets.indexOf(item) > -1) {
        matchOpeningBracket = openingBrackets[closingBrackets.indexOf(item)]
        if (bracketArray.length === 0 || (bracketArray.pop() !== matchOpeningBracket)) {
          this.matchingBracket = false;
          return false;
        }
      } else {
        bracketArray.push(item);
      }
    }

    this.matchingBracket = (bracketArray.length === 0);
    return this.matchingBracket;
  };
}
