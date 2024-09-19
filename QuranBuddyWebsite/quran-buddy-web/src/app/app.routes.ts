import { Routes } from '@angular/router';


export const routes: Routes = [
    //{ path: '**', redirectTo: 'chapters' },
    {
        path: 'chapters',
        loadComponent: () => import('./chapter-list/chapter-list.component').then(c => c.ChapterListComponent)           
    },
    {
        path: 'chapter/:id',
        loadComponent: () => import('./chapter-view/chapter-view.component').then(c => c.ChapterViewComponent)           
    },
    {
        path: 'create-flashcards',
        loadComponent: () => import('./create-flashcardset/create-flashcardset.component').then(c => c.CreateFlashcardsetComponent)           
    },
    {
        path: 'flashcardset-view/:id',
        loadComponent: () => import('./flashcardset-view/flashcardset-view.component').then(c => c.FlashcardsetViewComponent)           
    },
    {
        path: 'flashcardsets',
        loadComponent: () => import('./flashcardset-list/flashcardset-list.component').then(c => c.FlashcardsetListComponent)           
    },
];
