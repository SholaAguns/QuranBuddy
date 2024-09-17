import { Component, Input } from '@angular/core';
import { Verse } from '../shared/models/verse';

@Component({
  selector: 'app-verse-view',
  standalone: true,
  imports: [],
  templateUrl: './verse-view.component.html',
  styleUrl: './verse-view.component.scss'
})
export class VerseViewComponent {
  @Input() verse!: Verse;
}
