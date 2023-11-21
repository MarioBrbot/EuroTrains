import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-trains',
  templateUrl: './search-trains.component.html',
  styleUrls: ['./search-trains.component.css']
})
export class SearchTrainsComponent implements OnInit {

  searchResult: TrainsRm[] = [
    {
      company: "Hrvatske Željeznice",
      remainingNumberOfSeats: 400,
      departure: { time: Date.now().toString(), place: "Zagreb" },
      arrival: { time: Date.now().toString(), place: "Osijek" },
      price: "40",
    },
    {
      company: "Hekurudha Shqiptare",
      remainingNumberOfSeats: 60,
      departure: { time: Date.now().toString(), place: "Tirana" },
      arrival: { time: Date.now().toString(), place: "Zagreb" },
      price: "60",
    },
    {
      company: "Österreichische Bundesbahnen",
      remainingNumberOfSeats: 60,
      departure: { time: Date.now().toString(), place: "Vienna" },
      arrival: { time: Date.now().toString(), place: "Zagreb" },
      price: "60",
    },
  ]


  constructor() { }

  ngOnInit(): void {
  }

}


export interface TrainsRm {
  company: string;
  arrival: TimePlaceRm;
  departure: TimePlaceRm;
  price: string;
  remainingNumberOfSeats: number;
}

export interface TimePlaceRm {
  place: string;
  time: string;
}
