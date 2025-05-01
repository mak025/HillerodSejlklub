const toggleButton = document.getElementById('toggle-btn')
const sideBar = document.getElementById('sideBar')

function toggleSidebar() {
    sideBar.classList.toggle('close')
    toggleButton.classList.toggle('rotate')

    // This ensures that the sub menu is closed when the navbar is closed.
    // This is done by checking if the ul with the classname "submenu" has
    // the class "show" in the classlist and if it does, the class "show" is removed.
    Array.from(sideBar.getElementsByClassName('submenu')).forEach(ul => {
        if (ul.classList.contains('show')) {
            ul.classList.remove('show')
            ul.previousElementSibling.classList.remove('rotate')
        }
    })
}
//Toggles the submenu (musikerne) when the user clicks on the button
//Rotates the svg arrow 180 degrees on same interaction
function toggleSubMenu(button) {
    button.nextElementSibling.classList.toggle('show')
    button.classList.toggle('rotate')

    // This ensures that the navbar is openeed if the user clicks on a sub menu when the navbar is closed
    if (sideBar.classList.contains('close')) {
        sideBar.classList.remove('close')
        toggleButton.classList.remove('rotate')
    }
}
