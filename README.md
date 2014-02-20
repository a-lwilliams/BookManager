BookManager
===========

Very simple ASP.Net MVC test project that allows users to create and manage a wishlist of books. Written in a few days to try and get an idea of how the framework works.

Features
--------

* Relatively responsive design (see screenshots)
  * Fluid grid & UI from http://ink.sapo.pt/
  * Font icons: http://fortawesome.github.io/Font-Awesome/
  * SASS for CSS pre-processing
  * jQuery and some plugins (parallax scrolling etc)
* Simple wishlist management
  * Add and remove books from the list
  * Links to Amazon to allow purchasing
  * Uses a `Book` model which is attached to the user's model
  * Hopefully protected against XSS & CSRF
  * Validation
  * Uses built-in auth system for user management

Issues
------

* No unit testing
* No way to edit book entries other than removing and re-adding
* Amazon link is very hacky and abuses Google's *I'm feeling lucky* system
* Design isn't great (some padding & spacing issues)
