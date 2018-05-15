import { NbClassifierPage } from './app.po';

describe('nb-classifier App', () => {
  let page: NbClassifierPage;

  beforeEach(() => {
    page = new NbClassifierPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
