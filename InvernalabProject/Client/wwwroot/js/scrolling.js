const sectionId = "@IdSection";

function scrollToSection(sectionId) {
  const section = document.getElementById(sectionId);

  if (section) {
    section.scrollIntoView({ behavior: 'smooth' });

    // Agregar clase active-link a la sección actual
    const links = document.querySelectorAll('.nav-link');
    links.forEach(link => link.classList.remove('active-link'));

    const link = document.getElementById(sectionId + "-link");
    if (link) {
      link.classList.add('active-link');
    }
  }
}


